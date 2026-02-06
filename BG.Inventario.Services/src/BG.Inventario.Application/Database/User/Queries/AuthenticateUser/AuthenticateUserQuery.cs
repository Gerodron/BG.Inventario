using AutoMapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.User.Queries.AuthenticateUser
{
    public class AuthenticateUserQuery : IAuthenticateUserQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthenticateUserQuery> _logger;

        public AuthenticateUserQuery(IDatabaseService databaseService, IMapper mapper, ILogger<AuthenticateUserQuery> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AuthenticateUserResponse> Execute(AuthenticateUserModel model)
        {
            try
            {
                _logger.LogInformation("Intentando autenticar al usuario: {UserName}", model.UserName);

                var userEntity = await _databaseService.User
                    .FirstOrDefaultAsync(u => u.UserName == model.UserName && u.Password == model.Password);

                if (userEntity == null)
                {
                    _logger.LogWarning("Intento de login fallido para el usuario: {UserName}", model.UserName);
                    return null;
                }

                _logger.LogInformation("Usuario {UserName} autenticado exitosamente.", model.UserName);
                return _mapper.Map<AuthenticateUserResponse>(userEntity);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error de base de datos durante la autenticación del usuario: {UserName}", model.UserName);
                throw new Exception("Error de conexión con el servidor de datos al intentar iniciar sesión.", ex);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogCritical(ex, "Error de mapeo: Los datos de la entidad User no coinciden con AuthenticateUserResponse.");
                throw new Exception("Error interno al procesar el perfil del usuario autenticado.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error no controlado en AuthenticateUserQuery para el usuario: {UserName}", model.UserName);
                throw new Exception("Ocurrió un error inesperado en el sistema de autenticación.", ex);
            }
        }
    }
}

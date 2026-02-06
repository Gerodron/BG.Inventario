using AutoMapper;
using BG.Inventario.Application.Database.Product.Queries.GetAllProducts.Models;
using BG.Inventario.Domain.Entities.Product;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IGetAllProductsQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductsQuery> _logger;

        public GetAllProductsQuery(IDatabaseService databaseService, IMapper mapper, ILogger<GetAllProductsQuery> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;   
            _logger = logger;
        }

        public async Task<List<GetAllProductsModel>> Execute()
        {
            try
            {
                _logger.LogInformation("Iniciando consulta global de productos.");

                var productEntities = await _databaseService.Product.ToListAsync();

                return _mapper.Map<List<GetAllProductsModel>>(productEntities);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error de infraestructura al listar productos.");
                throw new Exception("No se pudo obtener el catálogo de productos debido a un error de conexión.", ex);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogCritical(ex, "Fallo en el mapeo de la lista de productos.");
                throw new Exception("Error al procesar el formato de la lista de productos.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado en GetAllProductsQuery.");
                throw new Exception("Ocurrió un error interno al recuperar el catálogo.", ex);
            }
        }
    }
}

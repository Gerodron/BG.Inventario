using AutoMapper;
using BG.Inventario.Domain.Entities.Product;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BG.Inventario.Application.Database.Product.Commands.UpdateProductById
{
    public class UpdateProductByIdCommand : IUpdateProductByIdCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductByIdCommand> _logger;

        public UpdateProductByIdCommand(IDatabaseService databaseService, IMapper mapper, ILogger<UpdateProductByIdCommand> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Execute(UpdateProducByIdModel model)
        {
            try
            {
                var productEntity = await _databaseService.Product
                    .FirstOrDefaultAsync(x => x.ProductId == model.ProductId);
                if (productEntity == null) return false;

                _mapper.Map(model, productEntity);
                return await _databaseService.SaveAsync();
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogInformation("Los datos proporcionados no tienen el formato correcto para la actualización.");
                throw new Exception("Los datos proporcionados no tienen el formato correcto para la actualización.", ex);
            }
            catch (SqlException ex)
            {
                _logger.LogInformation("Error de comunicación con la base de datos de inventario. Intente más tarde.");
                throw new Exception("Error de comunicación con la base de datos de inventario. Intente más tarde.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Se produjo un error interno al procesar la actualización del producto.");
                throw new Exception("Se produjo un error interno al procesar la actualización del producto.", ex);
            }
        }
    }
}

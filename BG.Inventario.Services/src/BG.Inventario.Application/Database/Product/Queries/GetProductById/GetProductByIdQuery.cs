using AutoMapper;
using BG.Inventario.Application.Database.Product.Queries.GetAllProducts;
using BG.Inventario.Domain.Entities.Product;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IGetProductByIdQuery
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllProductsQuery> _logger;


        public GetProductByIdQuery(IDatabaseService databaseService, IMapper mapper, ILogger<GetAllProductsQuery> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetProductByIdModel> Execute(int id)
        {
            string metodName = nameof(GetProductByIdQuery);
            try
            {
                var product = await _databaseService.Product.FindAsync(id);
                return _mapper.Map<GetProductByIdModel>(product);
            }
            catch (AutoMapperMappingException ex)
            {
                _logger.LogError(ex, "Error de mapeo en {MethodName} para el producto con ID {ProductId}.", metodName, id);
                throw new Exception("Los datos proporcionados no tienen el formato correcto para el registro.", ex);
            }
            catch (SqlException ex)
            {
                _logger.LogError(ex, "Error de comunicación con la base de datos de inventario. Intente más tarde.");
                throw new Exception("Error de comunicación con la base de datos de inventario. Intente más tarde.", ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error inesperado en {MethodName}.", metodName);
                throw new Exception("Se produjo un error interno al obtener el registro del producto.", ex);
            }
        }
    }
}

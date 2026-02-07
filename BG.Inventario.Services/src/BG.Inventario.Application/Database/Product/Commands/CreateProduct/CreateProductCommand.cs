using AutoMapper;
using BG.Inventario.Domain.Entities.Product;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Commands.CreateProduct
{
    public class CreateProductCommand : ICreateProductCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommand> _logger;

        public CreateProductCommand(IDatabaseService databaseService, IMapper mapper, ILogger<CreateProductCommand> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Execute(CreateProductModel model)
        {
            try
            {
                var productEntity = _mapper.Map<ProductEntity>(model);
                productEntity.Status = "ACTIVO";
                await _databaseService.Product.AddAsync(productEntity);

                return await _databaseService.SaveAsync();
            }
            catch (AutoMapperMappingException ex)
            {
                throw new Exception("Los datos proporcionados no tienen el formato correcto para el registro.", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error de comunicación con la base de datos de inventario. Intente más tarde.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error interno al procesar el registro del producto.", ex);
            }
        }
    }
}

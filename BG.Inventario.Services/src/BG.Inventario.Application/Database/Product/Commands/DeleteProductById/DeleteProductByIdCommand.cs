using AutoMapper;
using BG.Inventario.Application.Database.Product.Commands.CreateProduct;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Commands.DeleteProductById
{
    public class DeleteProductByIdCommand : IDeleteProductByIdCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommand> _logger;

        public DeleteProductByIdCommand(IDatabaseService databaseService, IMapper mapper, ILogger<CreateProductCommand> logger)
        {
            _databaseService = databaseService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Execute(int id)
        {
            try
            {
                var productEntity = await _databaseService.Product.FindAsync(id);
                if (productEntity == null) return false;
                productEntity.Status = "INACTIVE";
                return await _databaseService.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Se produjo un error interno al procesar la eliminación del producto con ID {ProductId}.", id);
                throw new Exception("Se produjo un error interno al procesar la eliminación del producto.", ex);
            }
        }
    }
}

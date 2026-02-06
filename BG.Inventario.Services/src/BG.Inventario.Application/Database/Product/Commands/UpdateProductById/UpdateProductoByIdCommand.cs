using AutoMapper;
using BG.Inventario.Domain.Entities.Product;
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
            ProductEntity productEntity = await _databaseService.Product
                .FirstOrDefaultAsync(x => x.ProductId == model.ProductId);

            if (productEntity == null) return false;

            _mapper.Map(model, productEntity);
            var result = await _databaseService.SaveAsync();

            return result;
        }
    }
}

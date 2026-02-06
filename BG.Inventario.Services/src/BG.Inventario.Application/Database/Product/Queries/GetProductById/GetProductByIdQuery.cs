using AutoMapper;
using BG.Inventario.Application.Database.Product.Queries.GetAllProducts;
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
            var product = await _databaseService.Product.FindAsync(id);
            return _mapper.Map<GetProductByIdModel>(product);
        }
    }
}

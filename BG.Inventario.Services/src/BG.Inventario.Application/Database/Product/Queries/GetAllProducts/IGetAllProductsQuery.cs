using BG.Inventario.Application.Database.Product.Queries.GetAllProducts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Queries.GetAllProducts
{
    public interface IGetAllProductsQuery
    {
        Task<List<GetAllProductsModel>> Execute();
    }
}

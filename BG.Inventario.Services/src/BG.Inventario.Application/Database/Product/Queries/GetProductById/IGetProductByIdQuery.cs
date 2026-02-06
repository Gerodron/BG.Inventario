using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Queries.GetProductById
{
    public interface IGetProductByIdQuery
    {
        Task<GetProductByIdModel> Execute(int id);
    }
}

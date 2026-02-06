using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Commands.CreateProduct
{
    public interface ICreateProductCommand
    {
        Task<bool> Execute(CreateProductModel model);
    }
}

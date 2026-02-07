using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Commands.DeleteProductById
{
    public interface IDeleteProductByIdCommand
    {
        Task<bool> Execute(int id);
    }
}

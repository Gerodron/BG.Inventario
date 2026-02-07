using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Commands.UpdateProductById
{
    public interface IUpdateProductByIdCommand
    {
        Task<bool>  Execute(UpdateProducByIdModel model);
    }
}

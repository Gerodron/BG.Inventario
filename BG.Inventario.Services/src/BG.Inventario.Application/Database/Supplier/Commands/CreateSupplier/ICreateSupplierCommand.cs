using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Supplier.Commands.CreateSupplier
{
    public interface ICreateSupplierCommand
    {
        Task<bool> Execute(CreateSupplierModel model);
    }
}

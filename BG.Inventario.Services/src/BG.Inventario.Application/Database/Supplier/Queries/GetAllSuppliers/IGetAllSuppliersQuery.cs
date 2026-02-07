using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Supplier.Queries.GetAllSuppliers
{
    public interface IGetAllSuppliersQuery
    {
        Task<List<GetAllSuppliersModel>> Execute();
    }
}

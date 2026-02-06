using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliers
{
    public interface IGetProductSuppliersQuery
    {
        Task<List<GetProductSuppliersModel>> Execute();
    }
}

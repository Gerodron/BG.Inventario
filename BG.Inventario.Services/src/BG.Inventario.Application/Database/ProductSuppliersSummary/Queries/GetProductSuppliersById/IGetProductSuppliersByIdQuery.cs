using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliersById
{
    public interface IGetProductSuppliersByIdQuery
    {
        Task<List<GetProductSuppliersByIdSupplierModel>> Execute(int productId);
    }
}

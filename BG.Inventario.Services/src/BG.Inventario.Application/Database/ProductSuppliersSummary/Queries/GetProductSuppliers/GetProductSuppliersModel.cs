using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliers
{
    public class GetProductSuppliersModel
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public decimal PurcharsePrice { get; set; }
        public int MinimumOrderQuantity { get; set; }
    }
}

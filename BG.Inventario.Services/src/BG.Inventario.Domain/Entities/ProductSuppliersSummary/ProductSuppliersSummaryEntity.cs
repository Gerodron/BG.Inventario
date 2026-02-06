using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Domain.Entities.ProductSuppliersSummary
{
    public class ProductSuppliersSummaryEntity
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public decimal PurcharsePrice { get; set; }
        public int MinimumOrderQuantity { get; set; }
    }
}

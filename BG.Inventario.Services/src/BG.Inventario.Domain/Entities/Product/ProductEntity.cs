using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Domain.Entities.Product
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Stock { get; set; }
        public decimal SalePrice { get; set; }
    }
}

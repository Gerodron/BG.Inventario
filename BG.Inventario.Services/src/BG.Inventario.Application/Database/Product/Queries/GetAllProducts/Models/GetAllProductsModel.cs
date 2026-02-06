using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Queries.GetAllProducts.Models
{
    public class GetAllProductsModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int Stock { get; set; }
        public int SalePrice { get; set; }
    }
}

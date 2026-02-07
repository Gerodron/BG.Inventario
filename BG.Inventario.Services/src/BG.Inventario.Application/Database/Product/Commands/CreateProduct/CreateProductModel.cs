using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Commands.CreateProduct
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusProduct { get; set; }
        public int SalePrice { get; set; }
        public int Stock { get; set; }
    }
}

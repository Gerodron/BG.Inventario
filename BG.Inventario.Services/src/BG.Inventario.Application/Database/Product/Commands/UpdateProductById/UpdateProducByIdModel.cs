using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Product.Commands.UpdateProductById
{
    public class UpdateProducByIdModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StatusProduct { get; set; }
        public int Stock { get; set; }
        public decimal SalePrice { get; set; }
    }
}

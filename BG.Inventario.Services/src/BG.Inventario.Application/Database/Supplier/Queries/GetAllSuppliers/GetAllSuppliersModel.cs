using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Application.Database.Supplier.Queries.GetAllSuppliers
{
    public class GetAllSuppliersModel
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}

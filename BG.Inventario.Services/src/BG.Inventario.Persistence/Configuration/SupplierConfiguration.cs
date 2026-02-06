using BG.Inventario.Domain.Entities.Supplier;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Persistence.Configuration
{
    public class SupplierConfiguration
    {
        public SupplierConfiguration(EntityTypeBuilder<SupplierEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => x.SupplierId);
            entityBuilder.Property(x => x.Name).IsRequired();
            entityBuilder.Property(x => x.Email).IsRequired();
        }
    }
}

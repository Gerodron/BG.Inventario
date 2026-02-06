using BG.Inventario.Domain.Entities.ProductSuppliersSummary;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Persistence.Configuration
{
    public class ProductSuppliersSummaryConfiguration
    {
        public ProductSuppliersSummaryConfiguration(EntityTypeBuilder<ProductSuppliersSummaryEntity> entityBuilder)
        {
            entityBuilder.HasKey(x => new { x.ProductId, x.SupplierId });
            entityBuilder.Property(x => x.ProductName).IsRequired();
            entityBuilder.Property(x => x.SupplierName).IsRequired();
            entityBuilder.Property(x => x.PurcharsePrice)
                .HasPrecision(18, 2)
                .IsRequired();
            entityBuilder.Property(x => x.MinimumOrderQuantity).IsRequired();
        }
    }
}

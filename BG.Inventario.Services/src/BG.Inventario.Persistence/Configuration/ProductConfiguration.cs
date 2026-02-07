using BG.Inventario.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BG.Inventario.Persistence.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<ProductEntity> entityBuilder)
        {
            entityBuilder.HasKey(e => e.ProductId);
            entityBuilder.Property(e => e.Name).IsRequired();
            entityBuilder.Property(e => e.Description).IsRequired();
            entityBuilder.Property(e => e.Status).IsRequired();
            entityBuilder.Property(e => e.Stock).IsRequired();
            entityBuilder.Property(e => e.SalePrice).IsRequired();
            entityBuilder.Property(e => e.StatusProduct).IsRequired();
        }
    }
}

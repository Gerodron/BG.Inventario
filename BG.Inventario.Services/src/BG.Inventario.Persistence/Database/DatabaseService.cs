using BG.Inventario.Application.Database;
using BG.Inventario.Domain.Entities.Product;
using BG.Inventario.Domain.Entities.ProductSuppliersSummary;
using BG.Inventario.Domain.Entities.Supplier;
using BG.Inventario.Domain.Entities.User;
using BG.Inventario.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BG.Inventario.Persistence.Database
{
    public class DatabaseService : DbContext , IDatabaseService
    {
        public DatabaseService(DbContextOptions opt)
        : base(opt)
        {

        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<SupplierEntity> Supplier { get; set; }
        public DbSet<ProductSuppliersSummaryEntity> vw_ProductSupplierSumary { get; set; }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfigurations(modelBuilder);
        }

        public void EntityConfigurations(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<UserEntity>());
            new ProductConfiguration(modelBuilder.Entity<ProductEntity>());
            new SupplierConfiguration(modelBuilder.Entity<SupplierEntity>());
            new ProductSuppliersSummaryConfiguration(modelBuilder.Entity<ProductSuppliersSummaryEntity>());
        }
    }
}

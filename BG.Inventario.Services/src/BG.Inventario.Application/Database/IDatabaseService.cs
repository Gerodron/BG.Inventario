using BG.Inventario.Domain.Entities.Product;
using BG.Inventario.Domain.Entities.ProductSuppliersSummary;
using BG.Inventario.Domain.Entities.Supplier;
using BG.Inventario.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace BG.Inventario.Application.Database
{
    public interface IDatabaseService
    {
        DbSet<UserEntity> User { get; set; }
        DbSet<ProductEntity> Product { get; set; }
        DbSet<SupplierEntity> Supplier { get; set; }
        DbSet<ProductSuppliersSummaryEntity> vw_ProductSupplierSumary { get; set; }
        Task<bool> SaveAsync();
    }
}

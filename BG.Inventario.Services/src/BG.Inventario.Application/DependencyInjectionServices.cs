using AutoMapper;
using BG.Inventario.Application.Configuration;
using BG.Inventario.Application.Database.Product.Commands.CreateProduct;
using BG.Inventario.Application.Database.Product.Commands.UpdateProductById;
using BG.Inventario.Application.Database.Product.Queries.GetAllProducts;
using BG.Inventario.Application.Database.Product.Queries.GetProductById;
using BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliers;
using BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliersById;
using BG.Inventario.Application.Database.User.Queries.AuthenticateUser;
using Microsoft.Extensions.DependencyInjection;

namespace BG.Inventario.Application
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            #region AutoMapper Configuration
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            services.AddSingleton(mapper.CreateMapper());
            #endregion
            services.AddTransient<IGetAllProductsQuery, GetAllProductsQuery>();
            services.AddTransient<IGetProductSuppliersByIdQuery, GetProductSuppliersByIdQuery>();
            services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<IAuthenticateUserQuery, AuthenticateUserQuery>();
            services.AddTransient<IGetProductSuppliersQuery, GetProductSuppliersQuery>();
            services.AddTransient<IUpdateProductByIdCommand, UpdateProductByIdCommand>();
            services.AddTransient<IGetProductByIdQuery, GetProductByIdQuery>();
            return services;
        }
    }
}

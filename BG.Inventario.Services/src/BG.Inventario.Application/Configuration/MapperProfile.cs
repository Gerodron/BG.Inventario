using AutoMapper;
using BG.Inventario.Application.Database.Product.Commands.CreateProduct;
using BG.Inventario.Application.Database.Product.Commands.UpdateProductById;
using BG.Inventario.Application.Database.Product.Queries.GetAllProducts.Models;
using BG.Inventario.Application.Database.Product.Queries.GetProductById;
using BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliers;
using BG.Inventario.Application.Database.ProductSuppliersSummary.Queries.GetProductSuppliersById;
using BG.Inventario.Application.Database.User.Queries.AuthenticateUser;
using BG.Inventario.Domain.Entities.Product;
using BG.Inventario.Domain.Entities.ProductSuppliersSummary;
using BG.Inventario.Domain.Entities.User;

namespace BG.Inventario.Application.Configuration
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductEntity, GetAllProductsModel>().ReverseMap();
            CreateMap<ProductSuppliersSummaryEntity, GetProductSuppliersByIdModel>().ReverseMap();
            CreateMap<ProductSuppliersSummaryEntity, GetProductSuppliersModel>().ReverseMap();
            CreateMap<ProductEntity, CreateProductModel>().ReverseMap();
            CreateMap<UserEntity, AuthenticateUserResponse>().ReverseMap();
            CreateMap<ProductEntity, UpdateProducByIdModel>().ReverseMap();
            CreateMap<ProductEntity, GetProductByIdModel>().ReverseMap();
        }
    }
}

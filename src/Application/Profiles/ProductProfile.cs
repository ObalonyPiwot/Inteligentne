using AutoMapper;
using MyProject.Application.Models.Products;
using MyProject.Application.Features.Products.Commands.CreateProduct;
using MyProject.Application.Features.Products.Commands.UpdateProduct;
using MyProject.Application.Features.Common;
using Domain.Entities;
namespace MyProject.Application.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductEntity>();

            CreateMap<ProductEntity, SelectlistResult>();

            CreateMap<CreateProductCommand, ProductEntity>();

            CreateMap<UpdateProductCommand, ProductEntity>();

            CreateMap<ProductEntity, ProductViewModel>();
        }
    }
}

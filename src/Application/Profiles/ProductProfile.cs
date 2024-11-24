using AutoMapper;
using MyProject.Application.Models.Productes;
using MyProject.Application.Features.Productes.Commands.CreateProduct;
using MyProject.Application.Features.Productes.Commands.UpdateProduct;
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

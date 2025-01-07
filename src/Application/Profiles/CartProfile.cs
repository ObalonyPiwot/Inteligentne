using Application.Features.Cart.CreateCart;
using AutoMapper;
using Domain.Entities;
using MyProject.Application.Features.Common;
using MyProject.Application.Features.Products.Commands.CreateProduct;
using MyProject.Application.Features.Products.Commands.UpdateProduct;
using MyProject.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CreateCartCommand, CartEntity>();
        }
    }
}

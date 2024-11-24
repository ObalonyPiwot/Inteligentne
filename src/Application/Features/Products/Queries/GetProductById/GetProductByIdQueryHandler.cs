using AutoMapper;
using MyProject.Application.Features.Common.Queries.GetById;
using MyProject.Application.Models.Productes;
using MyProject.Persistance.Context;
using Domain.Entities;
namespace MyProject.Application.Features.Productes.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : GetByIdQueryHandler<ProductEntity, GetProductByIdQuery, ProductViewModel>
    {
        public GetProductByIdQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}

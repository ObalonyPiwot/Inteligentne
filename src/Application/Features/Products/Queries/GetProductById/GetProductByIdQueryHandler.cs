using AutoMapper;
using MyProject.Application.Features.Common.Queries.GetById;
using MyProject.Application.Models.Products;
using MyProject.Persistance.Context;
using Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : GetByIdQueryHandler<ProductEntity, GetProductByIdQuery, ProductViewModel>
    {
        public GetProductByIdQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override IQueryable<ProductEntity> GetFilteredQuery(GetProductByIdQuery request)
        {
            var query = DbSet.Where(x => x.IsActive.Equals(true));
            return query
               .Include(x => x.Brand)
               .Include(x => x.ProductCategory)
               .Include(x => x.ProductColor)
               .Include(x => x.ProductGender)
               .Include(x => x.ProductSeason)
               .Include(x => x.ProductCondition)
               .Include(x => x.ProductMaterial)
               .Include(x => x.ProductType);
        }
    }
}

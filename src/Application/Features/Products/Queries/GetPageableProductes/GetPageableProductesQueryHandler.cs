using AutoMapper;
using MyProject.Application.Features.Common.Queries.GetPageable;
using MyProject.Application.Models.Products;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Entities;
using Azure;
using MyProject.Application.Features.Common;

namespace MyProject.Application.Features.Products.Queries.GetPageableProducts
{
    public class GetPageableProductsQueryHandler : GetPageableQueryHandler<ProductEntity, GetPageableProductsQuery, ProductViewModel>
    {
        public GetPageableProductsQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override Expression<Func<ProductEntity, bool>> FilterExpression(string word)
        {
            return c =>
                (EF.Functions.Like(c.Name, word));
        }
        protected override IQueryable<ProductEntity> GetFilteredQuery(GetPageableProductsQuery request)
        {
            var query = base.GetFilteredQuery(request);
            return query
                .Include(x=>x.Brand)
                .Include(x=>x.ProductCategory)
                .Include(x=>x.ProductColor)
                .Include(x=>x.ProductGender)
                .Include(x=>x.ProductSeason)
                .Include(x=>x.ProductCondition)
                .Include(x=>x.ProductMaterial)
                .Include(x=>x.ProductType);
        }
        protected override IQueryable<ProductEntity> GetOrderBy(IQueryable<ProductEntity> query, string? orderBy, bool desc)
        {
            orderBy = orderBy?.ToLower();
            return (orderBy, desc) switch
            {
                ("name", true) => query.OrderByDescending(_ => _.Name),

                ("name", false) => query.OrderBy(_ => _.Name),

                _ => query.OrderByDescending(_ => _.Created)
            };
        }
    }
}

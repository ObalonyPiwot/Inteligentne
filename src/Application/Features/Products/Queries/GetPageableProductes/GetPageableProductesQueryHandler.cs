using AutoMapper;
using MyProject.Application.Features.Common.Queries.GetPageable;
using MyProject.Application.Models.Productes;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Entities;

namespace MyProject.Application.Features.Productes.Queries.GetPageableProductes
{
    public class GetPageableProductesQueryHandler : GetPageableQueryHandler<ProductEntity, GetPageableProductesQuery, ProductViewModel>
    {
        public GetPageableProductesQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override Expression<Func<ProductEntity, bool>> FilterExpression(string word)
        {
            return c =>
                (EF.Functions.Like(c.Name, word));
        }
        protected override IQueryable<ProductEntity> GetFilteredQuery(GetPageableProductesQuery request)
        {
            var query = base.GetFilteredQuery(request);
            return query;
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

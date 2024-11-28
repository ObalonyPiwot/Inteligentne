using AutoMapper;
using MyProject.Application.Features.Common.Queries.GetSelectable;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Entities;
namespace MyProject.Application.Features.Products.Queries.GetSelectableProducts
{
    public class GetSelectableProductsQueryHandler : GetSelectableQueryHandler<ProductEntity, GetSelectableProductsQuery>
    {
        public GetSelectableProductsQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override Expression<Func<ProductEntity, bool>> FilterExpression(string word)
        {
            return c =>
                EF.Functions.Like(c.Name, word);
        }
    }
}

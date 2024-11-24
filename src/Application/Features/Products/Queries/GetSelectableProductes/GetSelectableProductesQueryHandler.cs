using AutoMapper;
using MyProject.Application.Features.Common.Queries.GetSelectable;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Domain.Entities;
namespace MyProject.Application.Features.Productes.Queries.GetSelectableProductes
{
    public class GetSelectableProductesQueryHandler : GetSelectableQueryHandler<ProductEntity, GetSelectableProductesQuery>
    {
        public GetSelectableProductesQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override Expression<Func<ProductEntity, bool>> FilterExpression(string word)
        {
            return c =>
                EF.Functions.Like(c.Name, word);
        }
    }
}

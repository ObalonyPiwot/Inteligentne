using AutoMapper;
using MyProject.Application.Features.Common.Queries.GetSelectable;
using MyProject.Domain.Entities;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MyProject.Application.Features.Cargoes.Queries.GetSelectableCargoes
{
    public class GetSelectableCargoesQueryHandler : GetSelectableQueryHandler<CargoEntity, GetSelectableCargoesQuery>
    {
        public GetSelectableCargoesQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override Expression<Func<CargoEntity, bool>> FilterExpression(string word)
        {
            return c =>
                EF.Functions.Like(c.Test, word);
        }
    }
}

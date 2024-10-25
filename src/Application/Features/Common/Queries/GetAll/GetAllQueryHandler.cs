using AutoMapper;
using MyProject.Domain.Common;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MyProject.Application.Features.Common.Queries.GetAll
{
    public class GetAllQueryHandler<TEntity, TRequest, TResponse> : BaseQueryHandler<TEntity, TRequest, IEnumerable<TResponse>>
        where TEntity : BaseAuditableEntity
        where TRequest : GetAllQuery<TResponse>
    {
        public GetAllQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<BaseResponse<IEnumerable<TResponse>>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            IQueryable<TEntity> query = GetFilteredQuery(request);

            List<TEntity> entities = await query
                .OrderByDescending(x => x.Created)
                .ToListAsync();

            IEnumerable<TResponse> result = Mapper.Map<IEnumerable<TResponse>>(entities);
            entities.Clear();
            return new BaseResponse<IEnumerable<TResponse>>(HttpStatusCode.OK, result);
        }

        protected virtual IQueryable<TEntity> GetFilteredQuery(TRequest request)
        {
            return DbSet.Where(x => x.IsActive.Equals(true));
        }
    }
}

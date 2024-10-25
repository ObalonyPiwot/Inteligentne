using AutoMapper;
using MyProject.Domain.Common;
using MyProject.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Application.Features.Common.Queries
{
    public abstract class BaseQueryHandler<TEntity, TRequest, TResponse> : IRequestHandler<TRequest, BaseResponse<TResponse>>
        where TEntity : BaseAuditableEntity
        where TRequest : IRequest<BaseResponse<TResponse>>
        where TResponse : class
    {
        protected IMyProjectDbContext DbContext;
        protected IMapper Mapper;
        protected DbSet<TEntity> DbSet { get; set; }

        protected BaseQueryHandler(IMyProjectDbContext dbContext, IMapper mapper)
        {
            DbContext = dbContext;
            Mapper = mapper;
            DbSet = DbContext.Set<TEntity>();
        }

        public abstract Task<BaseResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}

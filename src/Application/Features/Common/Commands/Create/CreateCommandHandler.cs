using AutoMapper;
using MyProject.Domain.Common;
using MyProject.Persistance.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MyProject.Application.Features.Common.Commands.Create
{
    public class CreateCommandHandler<TEntity, TRequest> : BaseCommandHandler<TEntity, TRequest>
        where TEntity : BaseAuditableEntity
        where TRequest : IRequest<BaseResponse>
    {
        public CreateCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<BaseResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<TEntity>(request);
            await DbSet.AddAsync(entity, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);
            
            return new BaseResponse(statusCode: HttpStatusCode.Created);
        }
    }

    public class CreateCommandHandler<TEntity, TRequest, TResponse> : BaseCommandHandler<TEntity, TRequest, TResponse>
    where TEntity : BaseAuditableEntity
    where TRequest : IRequest<BaseResponse<TResponse>>
    {
        public CreateCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<BaseResponse<TResponse>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var entity = Mapper.Map<TEntity>(request);
            await DbSet.AddAsync(entity, cancellationToken);
            await DbContext.SaveChangesAsync(cancellationToken);
            var model = Mapper.Map<TResponse>(entity);

            return new BaseResponse<TResponse>(statusCode: HttpStatusCode.Created, content: model);
        }

        public virtual async Task<TEntity?> getEntityAsync(Guid newEntityId, CancellationToken cancellationToken)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(newEntityId), cancellationToken);
        }
    }
}

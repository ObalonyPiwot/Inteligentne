﻿using AutoMapper;
using MyProject.Domain.Common;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MyProject.Application.Features.Common.Commands.Update
{
    public class UpdateCommandHandler<TEntity, TRequest> : BaseCommandHandler<TEntity, TRequest>
    where TEntity : BaseAuditableEntity
    where TRequest : BaseIdentifiableRequest
    {
        public UpdateCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<BaseResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity? entity = getEntityAsync(request, cancellationToken).Result;
            if (entity != null)
            {
                Mapper.Map(request, entity);
                await DbContext.SaveChangesAsync(cancellationToken);
                return new BaseResponse(statusCode: HttpStatusCode.OK);
            }
            else
            {
                return new BaseResponse(statusCode: HttpStatusCode.NotFound,
                    error: $"Object of type \"{typeof(TEntity).Name}\" with Id = {request.Id} was not found.");
            }
        }

        public virtual async Task<TEntity?> getEntityAsync(TRequest request, CancellationToken cancellationToken)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        }
    }
}

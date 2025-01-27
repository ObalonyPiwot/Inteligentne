﻿using AutoMapper;
using MyProject.Domain.Common;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MyProject.Application.Features.Common.Commands.Delete
{
    public abstract class DeleteCommandHandler<TEntity, TRequest> : BaseCommandHandler<TEntity, TRequest>
        where TEntity : BaseAuditableEntity
        where TRequest : BaseIdentifiableRequest
    {
        public DeleteCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<BaseResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity? entity = await DbSet.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
            if (entity != null)
            {
                entity.IsActive = false;
                await DbContext.SaveChangesAsync(cancellationToken);
                 return new BaseResponse(statusCode: HttpStatusCode.OK);
            }
            else
            {
                return new BaseResponse(statusCode: HttpStatusCode.NotFound,
                    error: $"Object of type \"{typeof(TEntity).Name}\" with Id = {request.Id} was not found.");
            }
        }

    }
}

using AutoMapper;
using MyProject.Application.Features.Common.Commands.Update;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace MyProject.Application.Features.Productes.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : UpdateCommandHandler<ProductEntity, UpdateProductCommand>
    {
        public UpdateProductCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<ProductEntity?> getEntityAsync(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await DbSet
                            .FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        }

        
    }
}

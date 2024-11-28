using AutoMapper;
using MyProject.Application.Features.Common.Commands.Create;
using MyProject.Application.Models.Products;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace MyProject.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : CreateCommandHandler<ProductEntity, CreateProductCommand, ProductViewModel>
    {
        public CreateProductCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<ProductEntity?> getEntityAsync(Guid newEntityId, CancellationToken cancellationToken)
        {
            return await DbSet
                              .FirstOrDefaultAsync(x => x.Id.Equals(newEntityId), cancellationToken);
        }
    }
}

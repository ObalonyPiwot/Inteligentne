using AutoMapper;
using MyProject.Application.Features.Common.Commands.Delete;
using MyProject.Persistance.Context;
using Domain.Entities;
namespace MyProject.Application.Features.Productes.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : DeleteCommandHandler<ProductEntity, DeleteProductCommand>
    {
        public DeleteProductCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}

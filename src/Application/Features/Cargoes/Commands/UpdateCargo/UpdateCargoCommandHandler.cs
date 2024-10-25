using AutoMapper;
using MyProject.Application.Features.Common.Commands.Update;
using MyProject.Domain.Entities;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Application.Features.Cargoes.Commands.UpdateCargo
{
    public class UpdateCargoCommandHandler : UpdateCommandHandler<CargoEntity, UpdateCargoCommand>
    {
        public UpdateCargoCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CargoEntity?> getEntityAsync(UpdateCargoCommand request, CancellationToken cancellationToken)
        {
            return await DbSet
                            .FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        }

        
    }
}

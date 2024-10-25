using AutoMapper;
using MyProject.Application.Features.Common.Commands.Create;
using MyProject.Application.Models.Cargoes;

using MyProject.Domain.Entities;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Application.Features.Cargoes.Commands.CreateCargo
{
    public class CreateCargoCommandHandler : CreateCommandHandler<CargoEntity, CreateCargoCommand, CargoViewModel>
    {
        public CreateCargoCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        public override async Task<CargoEntity?> getEntityAsync(Guid newEntityId, CancellationToken cancellationToken)
        {
            return await DbSet
                              .FirstOrDefaultAsync(x => x.Id.Equals(newEntityId), cancellationToken);
        }
    }
}

using AutoMapper;
using MyProject.Application.Features.Common;
using MyProject.Application.Features.Common.Commands.Delete;
using MyProject.Domain.Entities;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace MyProject.Application.Features.Cargoes.Commands.DeleteCargo
{
    public class DeleteCargoCommandHandler : DeleteCommandHandler<CargoEntity, DeleteCargoCommand>
    {
        public DeleteCargoCommandHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}

using AutoMapper;
using MyProject.Application.Features.Common;
using MyProject.Application.Features.Common.Queries.GetById;
using MyProject.Application.Models.Cargoes;

using MyProject.Domain.Entities;
using MyProject.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MyProject.Application.Features.Cargoes.Queries.GetCargoById
{
    public class GetCargoByIdQueryHandler : GetByIdQueryHandler<CargoEntity, GetCargoByIdQuery, CargoViewModel>
    {
        public GetCargoByIdQueryHandler(IMyProjectDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}

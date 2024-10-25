using AutoMapper;
using MyProject.Application.Models.Cargoes;
using MyProject.Domain.Entities;
using MyProject.Application.Features.Cargoes.Commands.CreateCargo;
using MyProject.Application.Features.Cargoes.Commands.UpdateCargo;
using MyProject.Domain.Enums;
using MyProject.Application.Features.Common;

namespace MyProject.Application.Profiles
{
    public class CargoProfile : Profile
    {
        public CargoProfile()
        {
            CreateMap<CargoEntity, CargoEntity>();

            CreateMap<CargoEntity, SelectlistResult>();

            CreateMap<CreateCargoCommand, CargoEntity>();

            CreateMap<UpdateCargoCommand, CargoEntity>();

            CreateMap<CargoEntity, CargoViewModel>();
        }
    }
}

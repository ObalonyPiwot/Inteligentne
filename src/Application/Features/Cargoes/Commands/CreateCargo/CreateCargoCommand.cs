using MyProject.Application.Features.Common;
using MyProject.Application.Models.Cargoes;

namespace MyProject.Application.Features.Cargoes.Commands.CreateCargo
{
    public class CreateCargoCommand : BaseRequest<CargoViewModel>
    {
        public string Test { get; set; } = null!;
    }
}

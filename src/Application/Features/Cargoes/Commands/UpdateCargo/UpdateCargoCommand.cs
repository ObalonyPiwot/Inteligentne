using MyProject.Application.Features.Common;

namespace MyProject.Application.Features.Cargoes.Commands.UpdateCargo
{
    public class UpdateCargoCommand : BaseIdentifiableRequest
    {
        public string Test { get; set; } = null!;
    }
}

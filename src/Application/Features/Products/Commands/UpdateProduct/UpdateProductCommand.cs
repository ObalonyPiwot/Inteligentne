using MyProject.Application.Features.Common;

namespace MyProject.Application.Features.Productes.Commands.UpdateProduct
{
    public class UpdateProductCommand : BaseIdentifiableRequest
    {
        public string Test { get; set; } = null!;
    }
}

using MyProject.Application.Features.Common;
using MyProject.Application.Models.Productes;

namespace MyProject.Application.Features.Productes.Commands.CreateProduct
{
    public class CreateProductCommand : BaseRequest<ProductViewModel>
    {
        public string Test { get; set; } = null!;
    }
}

using MyProject.Application.Features.Common;
using MyProject.Application.Models.Products;

namespace MyProject.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : BaseRequest<ProductViewModel>
    {
        public string Test { get; set; } = null!;
    }
}

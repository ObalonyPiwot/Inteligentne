using MyProject.Application.Features.Common;

namespace MyProject.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : BaseIdentifiableRequest
    {
        public string Test { get; set; } = null!;
    }
}

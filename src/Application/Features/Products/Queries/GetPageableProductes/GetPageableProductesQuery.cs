using MyProject.Application.Features.Common.Queries.GetPageable;
using MyProject.Application.Models.Products;

namespace MyProject.Application.Features.Products.Queries.GetPageableProducts
{
    public class GetPageableProductsQuery : GetPageableQuery<ProductViewModel>
    {
        public int? Category { get; set; }
        public int? Material { get; set; }
        public int? Gender { get; set; }
    }
}

using Azure;
using MyProject.Application.Features.Common;
using MyProject.Application.Features.Common.Queries.GetPageable;
using MyProject.Application.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.GetRecommendedPageableProducts
{
    public class GetRecommendedPageableProductsQuery : BaseRequest<PaginationResult<ProductViewModel>>
    {
    }
}

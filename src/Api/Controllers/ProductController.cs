using MyProject.Application.Features.Common;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Features.Products.Commands.CreateProduct;
using MyProject.Application.Models.Products;
using MyProject.Application.Features.Products.Queries.GetProductById;
using MyProject.Application.Features.Products.Queries.GetPageableProducts;
using Microsoft.AspNetCore.Authorization;
using Application.Features.Products.Queries.GetRecommendedPageableProducts;

namespace MyProject.API.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse<ProductViewModel>>> Create([FromBody] CreateProductCommand request)
            => await ExecuteRequest(request);

        [HttpGet("{Id}")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse<ProductViewModel>>> GetById([FromRoute] GetProductByIdQuery request)
          => await ExecuteRequest(request);
        [HttpGet("pageable")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse<PaginationResult<ProductViewModel>>>> GetPageable([FromQuery] GetPageableProductsQuery request)
          => await ExecuteRequest(request);
        [HttpGet("recommendedPageable")]
        [AllowAnonymous]
        public async Task<ActionResult<BaseResponse<PaginationResult<ProductViewModel>>>> GetRecommendedPageable([FromQuery] GetRecommendedPageableProductsQuery request)
          => await ExecuteRequest(request);

    }
}

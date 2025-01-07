using MyProject.Application.Features.Common;
using Microsoft.AspNetCore.Mvc;
using MyProject.Application.Features.Products.Commands.CreateProduct;
using MyProject.Application.Models.Products;
using MyProject.Application.Features.Products.Queries.GetProductById;
using MyProject.Application.Features.Products.Queries.GetPageableProducts;
using Microsoft.AspNetCore.Authorization;
using Application.Features.Products.Queries.GetRecommendedPageableProducts;
using Application.Features.Cart.CreateCart;

namespace MyProject.API.Controllers
{
    public class CartController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult<BaseResponse>> Create([FromBody] CreateCartCommand request)
            => await ExecuteRequest(request);

    }
}

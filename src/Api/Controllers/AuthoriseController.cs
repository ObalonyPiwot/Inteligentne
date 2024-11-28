using Application.Features.Authorise;
using Domain.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyProject.API.Controllers;
using MyProject.Application.Features.Common;

namespace Ilusi.API.Controllers
{
    public class AuthoriseController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<BaseResponse<TokenViewModel>>> GetToken([FromBody] GetTokenCommand command)
            => await Mediator.Send(command);

    }
}

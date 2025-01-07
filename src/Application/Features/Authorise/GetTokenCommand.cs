using Domain.Authorization;
using MediatR;
using MyProject.Application.Features.Common;

namespace Application.Features.Authorise
{
    public class GetTokenCommand: IRequest<BaseResponse<TokenViewModel>>
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

}

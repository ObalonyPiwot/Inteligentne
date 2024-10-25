using MediatR;

namespace MyProject.Application.Features.Common
{
    public class BaseRequest : IRequest<BaseResponse>
    {
    }

    public class BaseRequest<TResponse> : IRequest<BaseResponse<TResponse>>
    {
    }
}

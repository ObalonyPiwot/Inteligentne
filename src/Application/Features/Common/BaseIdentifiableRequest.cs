using MyProject.Application.Interfaces;

namespace MyProject.Application.Features.Common
{
    public class BaseIdentifiableRequest : BaseRequest, IIdentifiable
    {
        public Guid Id { get; set; }
    }

    public class BaseIdentifiableRequest<TResponse> : BaseRequest<TResponse>, IIdentifiable
    {
        public Guid Id { get; set; }
    }
}

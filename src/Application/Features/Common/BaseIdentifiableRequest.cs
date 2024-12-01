using MyProject.Application.Interfaces;

namespace MyProject.Application.Features.Common
{
    public class BaseIdentifiableRequest : BaseRequest, IIdentifiable
    {
        public int Id { get; set; }
    }

    public class BaseIdentifiableRequest<TResponse> : BaseRequest<TResponse>, IIdentifiable
    {
        public int Id { get; set; }
    }
}

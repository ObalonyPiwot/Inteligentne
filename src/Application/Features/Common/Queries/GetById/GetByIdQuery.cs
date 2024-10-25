namespace MyProject.Application.Features.Common.Queries.GetById
{
    public class GetByIdQuery<TResponse> : BaseIdentifiableRequest<TResponse>
        where TResponse : class
    {
    }
}

using ErrorOr;
using MediatR;

namespace Application.Interfaces
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, ErrorOr<TResponse>>
        where TQuery : IQuery<TResponse>
    {
    }
}

using ErrorOr;
using MediatR;

namespace Application.Interfaces
{
    public interface IQuery<TResposse> : IRequest<ErrorOr<TResposse>>
    {
    }
}

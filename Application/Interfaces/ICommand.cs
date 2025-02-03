using ErrorOr;
using MediatR;

namespace Application.Interfaces
{
    public interface ICommand : IRequest
    {
    }
    
    public interface ICommand<TResposse> : IRequest<ErrorOr<TResposse>>
    {
    }
}

﻿using ErrorOr;
using MediatR;

namespace Application.Interfaces
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand>
        where TCommand : ICommand
    {
    }

    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, ErrorOr<TResponse>>
        where TCommand : ICommand<TResponse>
    {
    }
}

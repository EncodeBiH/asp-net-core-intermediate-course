using MediatR;

namespace EmployeeManager.Application;

// https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse> where TCommand : ICommand<TResponse>
{
}

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
{
}
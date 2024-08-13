namespace EmployeeManager.Application;

// https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs

public interface ICommandHandler<TCommand, TResponse> where TCommand : ICommand<TResponse> where TResponse : class
{
	Task<TResponse> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}

public interface ICommandHandler<TCommand> where TCommand : ICommand 
{
	Task HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
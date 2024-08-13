using MediatR;

namespace EmployeeManager.Application;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

public interface ICommand : IRequest
{
}
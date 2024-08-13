using MediatR;

namespace EmployeeManager.Application;

public interface IQuery<TReponse> : IRequest<TReponse>
{
}
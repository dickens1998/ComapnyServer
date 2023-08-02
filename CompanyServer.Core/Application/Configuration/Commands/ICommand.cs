using MediatR;

namespace CompanyServer.Core.Application.Configuration.Commands;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
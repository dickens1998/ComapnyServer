using MediatR;

namespace CompanyServer.Core.Application.Configuration.Commands;

/// <summary>
/// 这个类是一个泛型接口 ICommand<>，用于表示一个命令请求对象，并且继承自 MediatR 框架的 IRequest<> 接口
/// out TResponse：表示该命令请求的响应结果的类型参数。
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
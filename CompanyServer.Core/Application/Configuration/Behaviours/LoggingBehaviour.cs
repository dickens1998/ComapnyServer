using MediatR.Pipeline;
using Serilog;

namespace CompanyServer.Core.Application.Configuration.Behaviours;

/// <summary>
///  日志记录行为
///  用于在处理 MediatR 请求之前记录请求的相关信息
/// </summary>
/// <typeparam name="TRequest"></typeparam>
public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest>
{
    private readonly ILogger _logger;

    public LoggingBehaviour(
        ILogger logger)
    {
        _logger = logger;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        _logger.Information("Tms Request: {Name} {@Request}",
            typeof(TRequest).Name, request);
        return Task.CompletedTask;
    }
}
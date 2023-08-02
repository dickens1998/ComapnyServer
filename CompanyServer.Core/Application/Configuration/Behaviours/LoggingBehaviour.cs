using MediatR.Pipeline;
using Serilog;

namespace CompanyServer.Core.Application.Configuration.Behaviours;

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
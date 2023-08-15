using CompanyServer.Core.Data;
using CompanyServer.Core.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace CompanyServer.UnitTetst;

public class FakeDbContext
{
    public static CompanyServerDbContext GetCompanyServerDbContext()
    {
        var mySql = new MySqlConnectionString(Substitute.For<IConfiguration>());

        mySql.Value.Returns("unit-test");
        return Substitute.For<CompanyServerDbContext>(mySql, new NoMediator());
    }

    private class NoMediator : IMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = new())
        {
            return Task.FromResult<TResponse>(default);
        }

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = new CancellationToken())
            where TRequest : IRequest
        {

            throw new NotImplementedException();
        }

        public Task<object> Send(object request, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(default(object));
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request,
            CancellationToken cancellationToken = new())
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<object> CreateStream(object request,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task Publish(object notification, CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.CompletedTask;
        }

        public Task Publish<TNotification>(TNotification notification,
            CancellationToken cancellationToken = new CancellationToken()) where TNotification : INotification
        {
            return Task.CompletedTask;
        }
    }
}
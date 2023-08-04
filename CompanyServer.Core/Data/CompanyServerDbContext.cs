using System.Data;
using System.Reflection;
using CompanyServer.Core.Application.Configuration.Data;
using CompanyServer.Core.Domain;
using CompanyServer.Core.Domain.Companys;
using CompanyServer.Core.Extensions;
using CompanyServer.Core.Infrastructure.Mediator;
using CompanyServer.Core.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace CompanyServer.Core.Data;

public class CompanyServerDbContext : DbContext, ITransactionContext
{
    private readonly MySqlConnectionString _connectionString;
    private IDbContextTransaction _currentTransaction;
    private readonly IMediator _mediator;

    public CompanyServerDbContext(MySqlConnectionString connectionString, IMediator mediator)
    {
        _connectionString = connectionString;
        _mediator = mediator;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseMySQL(_connectionString.Value, builder => builder.CommandTimeout(60))
        .LogTo(Console.WriteLine, LogLevel.Information)
        .UseSnakeCaseNamingConvention();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        typeof(CompanyServerDbContext).GetTypeInfo().Assembly.GetTypes()
            .Where(t => typeof(IEntity).IsAssignableFrom(t) && t.IsClass)
            .ForEach(x =>
            {
                if (modelBuilder.Model.FindEntityType(x) == null)
                    modelBuilder.Model.AddEntityType(x);
            });

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyEntityTypeConfiguration).Assembly);
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    /// <summary>
    /// 异步保存所有已更改的实体到数据库，并分发领域事件。首先通过中介器调用 DispatchDomainEventsAsync 方法来处理领域事件，
    /// 然后调用基类的 SaveChangesAsync 方法来保存更改，并返回保存是否成功的布尔值。
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        await _mediator.DispatchDomainEventsAsync(this);

        await base.SaveChangesAsync(cancellationToken);

        return true;
    }

    public bool HasActiveTransaction => _currentTransaction != null;

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        if (_currentTransaction != null) return null;

        _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);

        return _currentTransaction;
    }

    public async Task CommitTransactionAsync(IDbContextTransaction transaction)
    {
        if (transaction == null) throw new ArgumentNullException(nameof(transaction));

        if (transaction != _currentTransaction)
            throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

        try
        {
            await SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            RollbackTransaction();
            throw;
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }

    private void RollbackTransaction()
    {
        try
        {
            _currentTransaction?.Rollback();
        }
        finally
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}
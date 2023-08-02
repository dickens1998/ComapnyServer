using CompanyServer.Core.Domain.SeedWork;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CompanyServer.Core.Application.Configuration.Data;

/// <summary>
/// ITransactionContext 继承了 IUnitOfWork 接口，表示一个工作单元，用于管理数据持久化操作。
/// </summary>
public interface ITransactionContext : IUnitOfWork
{
    /// <summary>
    /// 用于检查是否存在活动的事务。它可以帮助在代码中判断当前是否存在有效的数据库事务。
    /// </summary>
    bool HasActiveTransaction { get; }

    /// <summary>
    /// 表示数据库访问的外观类 DatabaseFacade，可以用于执行各种数据库操作（例如查询、插入、更新和删除等）。
    /// </summary>
    DatabaseFacade Database { get; }

    /// <summary>
    /// BeginTransactionAsync() 方法用于开始一个新的事务并返回 IDbContextTransaction 对象。
    /// 这个方法通常在需要进行数据库操作的时候调用，以确保一组相关的数据库操作能够以原子方式提交或回滚。
    /// </summary>
    /// <returns></returns>
    Task<IDbContextTransaction> BeginTransactionAsync();

    /// <summary>
    /// CommitTransactionAsync(IDbContextTransaction transaction) 方法用于提交指定的数据库事务。通过调用该方法，就可以将之前在事务中进行的数据库操作保存到数据库中。
    /// </summary>
    /// <param name="transaction"></param>
    /// <returns></returns>
    Task CommitTransactionAsync(IDbContextTransaction transaction);
}
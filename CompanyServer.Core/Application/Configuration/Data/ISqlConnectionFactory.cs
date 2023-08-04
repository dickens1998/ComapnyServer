using System.Data;

namespace CompanyServer.Core.Application.Configuration.Data;

/// <summary>
/// 数据库连接相关的工厂类
/// 将数据库连接的创建和管理与实际的业务逻辑分离开来，提供了更好的可维护性和灵活性。
/// 使用这个接口，可以在应用程序中使用不同的数据库连接实现，而无需修改业务代码。
/// </summary>
public interface ISqlConnectionFactory : IDisposable
{
    /// <summary>
    /// 用于获取一个已打开的数据库连接（IDbConnection对象）。这个方法在调用时应该返回一个已经打开的可用连接，以便进行数据库操作。
    /// </summary>
    /// <returns></returns>
    IDbConnection GetOpenConnection();

    /// <summary>
    /// 用于创建一个新的数据库连接（IDbConnection对象）。这个方法在调用时应该返回一个新的、未打开的连接对象，以便根据需要进行打开和关闭。
    /// </summary>
    /// <returns></returns>
    IDbConnection CreateNewConnection();

    /// <summary>
    /// 返回用于连接数据库的连接字符串。连接字符串包含了连接数据库所需的信息
    /// </summary>
    /// <returns></returns>
    string GetConnectionString();
}
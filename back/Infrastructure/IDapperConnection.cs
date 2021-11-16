using System.Data;

namespace Infrastructure
{
    public interface IDapperConnection
    {
        IDbConnection GetConnection();
    }
}

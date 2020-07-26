using System.Data.SqlClient;
using MongoDB.Driver;

namespace DataAccessLayer
{
    public interface IDbConnection
    {
        SqlConnection GetSqlDbClient();

        MongoClient GetMongoDbClient();
    }
}

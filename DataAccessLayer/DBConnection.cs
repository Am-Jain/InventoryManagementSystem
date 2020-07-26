using System.Data.SqlClient;
using MongoDB.Driver;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class DBConnection : IDbConnection
    {
        private IInventoryDatabaseSettings _inventoryDatabaseSettings;

        public DBConnection(IInventoryDatabaseSettings inventoryDatabaseSettings)
        {
            _inventoryDatabaseSettings = inventoryDatabaseSettings;
        }


        public SqlConnection GetSqlDbClient()
        {
            return new SqlConnection(_inventoryDatabaseSettings.ConnectionString);
        }

        public MongoClient GetMongoDbClient()
        {
            return new MongoClient(_inventoryDatabaseSettings.ConnectionString);
        }

    }

}

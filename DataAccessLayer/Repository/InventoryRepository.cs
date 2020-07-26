using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Inventory.Data.Model;

namespace DataAccessLayer.Repository
{
    public class InventoryRepository : IInventoryRepository

    {
        private SqlConnection _dbConnection;

        public InventoryRepository(IDbConnection DbConnection)
        {
            _dbConnection = DbConnection.GetSqlDbClient();

            // For MongoDb client
            //_dbConnection = DbConnection.GetMongoDbClient();
        }
        public void Insert(List<string> List)
        {
            /* In case of MongoDb replace the below code with Mongoclient code  */

            string columnValues = string.Join(",", List);
            string sql = "Insert into Providertable values(" + columnValues + ")" ;
            SqlCommand cmd = new SqlCommand(sql, _dbConnection);
            _dbConnection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public InventoryModel Get()
        {
            throw new NotImplementedException();
        }

        public InventoryModel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}

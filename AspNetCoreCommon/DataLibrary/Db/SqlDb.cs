using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.Db
{
    public class SqlDb : IDataAccess
    {
        private readonly IConfiguration config;

        public SqlDb(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            // connectionString - full path
            // connectionStringName - name of the string in appSettings that contains full path
            // this way we can change connectionString even at runtime
            string connectionString = config.GetConnectionString(connectionStringName);

            // creates sql connection using connectionString
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // asyncronusly queries table rows according to parameters and stored procedure
                // then using Dapper creates object of type "T" from each row
                // after that adds T - objects to IEnumerable<T>
                IEnumerable<T> rows = await connection.QueryAsync<T>(storedProcedure,
                                                                     parameters,
                                                                     commandType: CommandType.StoredProcedure);

                // since we are expecting list last thing to do is to convert IEnumerable to List
                return rows.ToList();
            }
        }

        public async Task<int> SaveData<U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectionString = config.GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // saves data to database and return integer that usually represents how many rows were afected etc.
                return await connection.ExecuteAsync(storedProcedure,
                                                     parameters,
                                                     commandType: CommandType.StoredProcedure);

            }
        }
    }
}

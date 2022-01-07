using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class FoodData : IFoodData
    {
        private readonly IDataAccess dataAccess;
        private readonly ConnectionStringData connectionString;

        public FoodData(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            this.dataAccess = dataAccess;
            this.connectionString = connectionString;
        }

        public Task<List<FoodModel>> GetFood()
        {
            return dataAccess.LoadData<FoodModel, dynamic>("dbo.spFood_All",
                                                           new { },
                                                           connectionString.SqlConnectionName);
        }
    }
}

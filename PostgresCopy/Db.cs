using System.Configuration;
using LinqToDB.Data;
using LinqToDB.DataProvider.PostgreSQL;

namespace PostgresCopy
{
    public class Db : DataConnection
    {
        public Db() : base(new PostgreSQLDataProvider(), ConfigurationManager.ConnectionStrings["SearchLog"].ConnectionString)
        {
        }
    }
}
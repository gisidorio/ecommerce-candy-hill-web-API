using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Infra.Data
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(DatabaseSettings databaseSettings)
        {
            _connectionString = databaseSettings.ConnectionString;
        }

        public IDbConnection CriarConexaoBaseDeDados()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

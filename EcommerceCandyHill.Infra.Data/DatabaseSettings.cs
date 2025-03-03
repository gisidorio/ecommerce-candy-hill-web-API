using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Infra.Data
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; }

        public DatabaseSettings(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("CandyHillConnection")
                                ?? throw new ArgumentNullException("Connection string is missing.");
        }
    }
}

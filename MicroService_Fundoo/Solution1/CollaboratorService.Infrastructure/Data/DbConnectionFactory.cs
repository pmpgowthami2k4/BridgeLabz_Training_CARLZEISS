using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace CollaboratorService.Infrastructure.Data
{
    public class DbConnectionFactory
    {
        private readonly IConfiguration _config;

        public DbConnectionFactory(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(
                _config.GetConnectionString("DefaultConnection"));
        }
    }
}
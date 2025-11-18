using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommerce.infrastructure.DbContext;

public class DapperDbContext 
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection  _dbConnection;
    
    public DapperDbContext(IConfiguration  configuration)
    {
        _configuration = configuration;
        string? connectionString = _configuration.GetConnectionString("PostgresConnection");

        _dbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _dbConnection;
}
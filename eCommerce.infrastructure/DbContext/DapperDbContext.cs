using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommerce.infrastructure.DbContext;

public class DapperDbContext
{
    private readonly IConfiguration _configuration;
    private readonly IDbConnection _dbConnection;

    public DapperDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        string connectionStringTemplate = _configuration.GetConnectionString("PostgresConnection")!;
        string connectionString = connectionStringTemplate
            .Replace("$POSTGRES_HOST", Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "localhost")
            .Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? "postgres");

        _dbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _dbConnection;
}
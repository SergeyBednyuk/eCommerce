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
            .Replace("$POSTGRES_HOST", _configuration["POSTGRES_HOST"] ?? "localhost")
            .Replace("$POSTGRES_PASSWORD", _configuration["POSTGRES_PASSWORD"] ?? "Legion13")
            .Replace("$POSTGRES_PORT", _configuration["POSTGRES_PORT"] ?? "5432")
            .Replace("$POSTGRES_USER", _configuration["POSTGRES_USER"] ?? "postgres")
            .Replace("$POSTGRES_DATABASE", _configuration["POSTGRES_DATABASE"] ?? "eCommerce.Users");

        _dbConnection = new NpgsqlConnection(connectionString);
    }

    public IDbConnection DbConnection => _dbConnection;
}
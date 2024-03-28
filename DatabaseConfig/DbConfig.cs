using Npgsql;

namespace gamevault.DatabaseConfig;

public class DbConfig
{

    private readonly IConfiguration _configuration;

    public DbConfig(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetSchemaDatabase()
    {
        return _configuration.GetConnectionString("YourDataSchema") ?? throw new InvalidOperationException();
    }

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException();
    }

    public NpgsqlConnection GetConnectionDatabase()
    {
        string connectionString = GetConnectionString();
        string schema = GetSchemaDatabase();
        string connectionStringWithSchema = $"{connectionString};SearchPath={schema}";
        return new NpgsqlConnection(connectionStringWithSchema);

    }

}
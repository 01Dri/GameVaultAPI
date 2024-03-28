using Npgsql;

namespace gamevault.DatabaseConfig;

public class DbConfig
{

    private readonly IConfiguration _configuration;

    public DbConfig(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? GetSchemaDatabase()
    {
        return _configuration["Schema:YourDataSchema"];
    }

    public string GetConnectionString()
    {
        var stringConnection =  _configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException();
        Console.WriteLine(stringConnection);
        return stringConnection;
    }

    public NpgsqlConnection GetConnectionDatabase()
    {
        return new NpgsqlConnection(GetConnectionString() + ";SearchPath=" + GetSchemaDatabase());

    }

}
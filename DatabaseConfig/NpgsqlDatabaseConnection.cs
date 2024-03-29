using Npgsql;

namespace gamevault.DatabaseConfig;

public class NpgsqlDatabaseConnection : IDatabaseConnection
{

    private readonly IConfiguration _iConfiguration;


    public NpgsqlDatabaseConnection(IConfiguration iConfiguration)
    {
        _iConfiguration = iConfiguration;
    }

    private string ConnectionString()
    {
        return _iConfiguration.GetConnectionString("DefaultConnection") + ";SearchPath=" + SchemaDatabase();
    }

    public string SchemaDatabase()
    {
        return _iConfiguration["Schema:YourDataSchema"];
    }

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(ConnectionString());
    }
}
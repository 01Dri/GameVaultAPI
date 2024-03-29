using Npgsql;

namespace gamevault.DatabaseConfig;

public interface IDatabaseConnection
{
    string SchemaDatabase();

    NpgsqlConnection Connection();

}
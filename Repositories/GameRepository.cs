using gamevault.DatabaseConfig;
using gamevault.Models;
using Npgsql;

namespace gamevault.Repositories;

public class GameRepository : IGameRepository
{
    private DbConfig _dbConfig;

    public GameRepository(DbConfig dbConfig)
    {
        _dbConfig = dbConfig;
    }

    public void SaveGame(Game game)
    {
        string schema = _dbConfig.GetSchemaDatabase();
        string sql = $"INSERT INTO {schema}.gamevault (name, description, average_rating, genres, dowloands) VALUES (@Name, @Description, @AverageRating, @Genre, @Downloads)";
        using (var conn = _dbConfig.GetConnectionDatabase())
        {
            conn.Open();

            using (var command = new NpgsqlCommand(sql, conn))
            {
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@Description", game.Description);
                command.Parameters.AddWithValue("@Name", game.AverageRating);
                command.Parameters.AddWithValue("@Name", game.Genres);
                command.Parameters.AddWithValue("@Name", game.Downloads);
                command.ExecuteNonQuery();
            }
        }
    }
}
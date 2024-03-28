using gamevault.DatabaseConfig;
using gamevault.Exceptions;
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
        string? schema = _dbConfig.GetSchemaDatabase();
        string sql = $"INSERT INTO {schema}.gamevault (name, description, average_rating, genres, downloads) VALUES (@Name, @Description, @AverageRating, @Genre, @Downloads)";
        using (var conn = _dbConfig.GetConnectionDatabase())
        {
            try
            {
                conn.Open();
                using (var command = new NpgsqlCommand(sql, conn))
                {
                    command.Parameters.AddWithValue("@Name", game.Name);
                    command.Parameters.AddWithValue("@Description", game.Description);
                    command.Parameters.AddWithValue("@AverageRating", game.AverageRating);
                    command.Parameters.AddWithValue("@Genre", (int)game.Genres);
                    command.Parameters.AddWithValue("@Downloads", game.Downloads);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new FailedConnectionDatabaseException(ex.Message);
            } 
        }
    }
}
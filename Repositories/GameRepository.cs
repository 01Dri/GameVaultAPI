using gamevault.DatabaseConfig;
using gamevault.Enums;
using gamevault.Exceptions;
using gamevault.Models;
using Npgsql;

namespace gamevault.Repositories;

public class GameRepository : IGameRepository
{
    private readonly IDatabaseConnection _databaseConnection;

    public GameRepository(IDatabaseConnection databaseConnection)
    {
        _databaseConnection = databaseConnection;
    }


    public int SaveGame(Game game)
    {

        string sql =
            $"INSERT INTO {_databaseConnection.SchemaDatabase()}.gamevault (name, description, average_rating, genres, downloads) VALUES (@Name, @Description, @AverageRating, @Genre, @Downloads) RETURNING id";

        {
            using (var conn = _databaseConnection.Connection())
            using (var command = new NpgsqlCommand(sql, conn))
            {
                conn.Open();
                command.Parameters.AddWithValue("@Name", game.Name);
                command.Parameters.AddWithValue("@Description", game.Description);
                command.Parameters.AddWithValue("@AverageRating", game.AverageRating);
                command.Parameters.AddWithValue("@Genre", (int)game.Genres);
                command.Parameters.AddWithValue("@Downloads", game.Downloads);
                var id = command.ExecuteScalar();
                if (id != null && id != DBNull.Value)
                {
                    return Convert.ToInt32(id);
                }

                throw new FailedToSaveGameOnDbException("Failed to insert game on DB !");
            }
        }
    }

    public List<Game> FindAllGames()
    {
        string sql =
            $"SELECT * FROM {_databaseConnection.SchemaDatabase()}.gamevault";

        using (var conn = _databaseConnection.Connection())
        using (var command = new NpgsqlCommand(sql, conn))
        {
            conn.Open();
            using (var reader = command.ExecuteReader())
            {
                List<Game> games = new List<Game>();
                while (reader.Read())
                {
                    var product = new Game
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        AverageRating = reader.GetDouble(3),
                        Genres = (Genres)reader.GetInt32(4),
                        Downloads = reader.GetInt32(5)
                    };
                    games.Add(product);
                }

                return games;
            }
        }
    }
}


using gamevault.Models;

namespace gamevault.Repositories;

public interface IGameRepository
{

    int SaveGame(Game game);

    List<Game> FindAllGames();
}
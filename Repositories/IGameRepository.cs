using gamevault.Models;

namespace gamevault.Repositories;

public interface IGameRepository
{

    void SaveGame(Game game);
    

}
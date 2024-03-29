using gamevault.Models;
using gamevault.Models.Dto;

namespace gamevault.Services;

public interface IGameService
{

    GameResponseDTO SaveGame(GameDTO gameDto);

    List<GameResponseDTO> FindAllGames();

}
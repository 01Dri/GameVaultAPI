using gamevault.Enums;
using gamevault.Models;
using gamevault.Models.Dto;
using gamevault.Repositories;

namespace gamevault.Services;

public class GameService : IGameService
{

    private IGameRepository _gameRepository;

    public GameService(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public GameResponseDTO SaveGame(GameDTO gameDto)
    {
        Genres genre = (Genres)Enum.Parse(typeof(Genres), gameDto.GenreName);
        Game game = new Game(null, gameDto.Name, gameDto.Description, gameDto.AverageRating, genre, 0);
        _gameRepository.SaveGame(game);
        return new GameResponseDTO(game.Name, game.Description, game.AverageRating, game.Genres.ToString(), 0);
    }
}
using gamevault.Enums;
using gamevault.Exceptions;
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
        Game game = new Game(null, gameDto.Name, gameDto.Description, 0, genre, 0);
        int id = _gameRepository.SaveGame(game);
        return new GameResponseDTO(id, game.Name, game.Description, game.AverageRating, game.Genres.ToString(), 0);
    }

    public List<GameResponseDTO> FindAllGames()
    {
        List<Game> games = _gameRepository.FindAllGames();
        return games.Select(x =>
            new GameResponseDTO(x.Id, x.Name, x.Description, x.AverageRating, x.Genres.ToString(), x.Downloads)).ToList();

    }
}
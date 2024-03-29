using System.Data;
using gamevault.Controllers;
using gamevault.DatabaseConfig;
using gamevault.Enums;
using gamevault.Models;
using gamevault.Models.Dto;
using gamevault.Repositories;
using gamevault.Services;
using Moq;
using Npgsql;
using Xunit;

namespace gamevault.Tests.UnitTests;

public class GameServiceTest
{

    private readonly GameService _gameService;
    private readonly Mock<IGameRepository> _mockGameRepository = new Mock<IGameRepository>();
    private readonly Mock<IDatabaseConnection> _dataBaseMock = new Mock<IDatabaseConnection>();

    public GameServiceTest()
    {
        _gameService = new GameService(this._mockGameRepository.Object);
    }

    [Fact]
    public void Save_Game_Test()
    {
        // ARRANGE
        string name = "GTA";
        string description = "Essa é uma descricao";
        double averageRating = 2.5;
        string genreName = Genres.ACTION.ToString();
        GameDTO mockGameDto = new GameDTO(name, description, genreName);
        Game mockGame = new Game(1, name, description, 0, (Genres)Enum.Parse(typeof(Genres), genreName), 0);
        
        //ACT
        _mockGameRepository.Setup(x => x.SaveGame(It.IsAny<Game>())).Returns(1);
        var result = _gameService.SaveGame(mockGameDto);

        //ASSERT
        _mockGameRepository.Verify(x => x.SaveGame(It.IsAny<Game>()), Times.Once);
        Assert.NotNull(result);
        Assert.IsType<GameResponseDTO>(result);
        Assert.Equal(1, result.Id);
        Assert.Equal(mockGameDto.Name, result.Name);
        Assert.Equal(mockGameDto.Description, result.Description);
        Assert.Equal(0, result.AverageRating);
        Assert.Equal(mockGameDto.GenreName, result.GenreName);
        Assert.Equal(0, result.Downloads);
    }

    [Fact]
    public void FindAll_Game_By_Test()
    {
        // ARRANGE
        
        Game mockGame1 = new Game(1, "death stranding", "jogao", 4.5, Genres.ACTION, 123);
        Game mockGame2 = new Game(2, "gta", "jogao", 4.5, Genres.ACTION, 4);
        Game mockGame3 = new Game(3, "dragon ball", "jogao", 4.5, Genres.ACTION, 500);
        List<Game> mockListGames = new List<Game>() { mockGame1, mockGame2, mockGame3 };
        
        // ACT
        _mockGameRepository.Setup(x => x.FindAllGames()).Returns(mockListGames);
        var result = _gameService.FindAllGames();
        
        // ASSERT
        Assert.Equal(3, result.Count());

    }
    
}
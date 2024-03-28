using gamevault.Models.Dto;
using gamevault.Services;
using Microsoft.AspNetCore.Mvc;
namespace gamevault.Controllers;

public class GameController : Controller
{
    private readonly IGameService _gameService;

    public GameController(IGameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost]
    [Route("/game")]
    public IActionResult Post([FromBody] GameDTO gameDto)
    {
        var result = _gameService.SaveGame(gameDto);
        return Ok(result);
    }
}


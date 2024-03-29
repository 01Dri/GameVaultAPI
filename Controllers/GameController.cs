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
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = _gameService.SaveGame(gameDto);
        return CreatedAtAction(null, null, result);
    }
    
    [HttpGet]
    [Route("/game")]
    public IActionResult GetAll()
    {
        return Ok(_gameService.FindAllGames());
    }
}


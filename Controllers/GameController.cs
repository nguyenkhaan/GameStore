using GameStore.Dtos;
using GameStore.Exceptions;
using GameStore.Models;
using GameStore.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GameStore.Controllers;

[ApiController]
[Route("/api/games")]
public class GameController: ControllerBase
{
    private readonly GameService _gameService;
    public GameController(GameService gameService)
    {
        _gameService = gameService;
    }
    [HttpGet]
    public IActionResult GetGames()
    {
        var result = _gameService.GetGames();
        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetGameDetail(string id)
    {
        var result = _gameService.GetGameDetail(id);
        return result is null ? NotFound() : Ok(result);
    }
    public IActionResult CreateGame(CreateGameDto data)
    {
        var result = _gameService.CreateGame(data);
        return Created($"/api/games/{result.Id}", result);
    }
    [HttpPut("{id}")]
    public IActionResult UpdateGame(string id, UpdateGameDto data)
    {
        try
        {
            return Ok(_gameService.UpdateGame(id, data));
        } catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteGame(string id)
    {
        try
        {
            return Ok(_gameService.DeleteGame(id));
        } catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

using GameStore.Data;
using GameStore.Dtos;
using GameStore.Exceptions;
using GameStore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace GameStore.Services;

public class GameService
{
    private readonly List<GameDto> games = [
        new("game01" , "Street Fighter" , "Combat", 12.12M, new(2010, 10, 1)),
        new("game02", "Final Fantasy Report", "Fantasy", 12.99M, new(2010,10,10)),
        new ("game03", "Kamen Rider BattrideWar Sousei" , "RGB" , 19.99M, new(2012,12,12))
    ];
    private readonly GameStoreContext _dbContext;
    public GameService(GameStoreContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<Game> GetGames()
    {
        return _dbContext.Games.ToList();
    }
    public Game? GetGameDetail(string id)
    {
        return _dbContext.Games.FirstOrDefault(game => game.Id == id);
    }
    public Game CreateGame(CreateGameDto data)
    {
        Random rd = new();
        string id = $"game-{rd.Next(1, 100)}";
        var game = new Game
        {
            Id = Guid.NewGuid().ToString(),
            Name = data.Name,
            GenreId = data.Genre,
            Price = data.Price,
            ReleaseDate = data.ReleaseDate
        };
        _dbContext.Games.Add(game);
        _dbContext.SaveChanges();
        return game;
    }
    public Game UpdateGame(string id, UpdateGameDto data)
    {
        var game = _dbContext.Games.FirstOrDefault(game => game.Id == id);
        if (game is null) throw new NotFoundException("Game not found");
        if (data.Name is not null) game.Name = data.Name;
        if (data.Genre is not null) game.GenreId = data.Genre; //getter and setter will handle this 
        if (data.ReleaseDate is not null) game.ReleaseDate = data.ReleaseDate.Value;
        if (data.Price is not null) game.Price = data.Price.Value;

        _dbContext.SaveChanges();
        return game;
    }
    public string DeleteGame(string id)
    {
        var game = _dbContext.Games.FirstOrDefault(game => game.Id == id);
        if (game is null)
            throw new NotFoundException("Game not found");
        _dbContext.Games.Remove(game);
        _dbContext.SaveChanges();
        return "Delete successfully";
    }
}

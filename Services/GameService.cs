using GameStore.Dtos;
using GameStore.Exceptions;
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
    public List<GameDto> GetGames()
    {
        return games;
    }
    public GameDto? GetGameDetail(string id)
    {
        return games.Find(game => game.ID == id);
    }
    public GameDto CreateGame(CreateGameDto data)
    {
        Random rd = new();
        string id = $"game-{rd.Next(1, 100)}";
        var game = new GameDto
        {
            ID = id,
            Name = data.Name,
            Genre = data.Genre,
            Price = data.Price,
            ReleaseDate = data.ReleaseDate
        };
        games.Add(game);
        return game;
    }
    public GameDto UpdateGame(string id, UpdateGameDto data)
    {
        var game = games.Find((game) => game.ID == id);
        if (game is null) throw new NotFoundException("Game not found");
        if (data.Name is not null) game.Name = data.Name;
        if (data.Genre is not null) game.Genre = data.Genre; //getter and setter will handle this 
        if (data.ReleaseDate is not null) game.ReleaseDate = data.ReleaseDate.Value;
        if (data.Price is not null) game.Price = data.Price.Value;
        return game;
    }
    public string DeleteGame(string id)
    {
        var game = games.Find(game => game.ID == id);
        if (game is null)
            throw new NotFoundException("Game not found");
        games.Remove(game);
        return "Delete successfully";
    }
}

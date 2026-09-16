using GameStore.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
namespace GameStore.Endpoints;

public static class GameEndpoints
{
    const string GameEndpoint = "GetGame";
    //You don't need to adding static because const is already implicitly static 
    //When you write const, c# will treat it as a class-level constant. You can access it directly with: MyClass.ConstName;

    private static readonly List<GameDto> games = [
        new("game01" , "Street Fighter" , "Combat", 12.12M, new(2010, 10, 1)),
        new("game02", "Final Fantasy Report", "Fantasy", 12.99M, new(2010,10,10)),
        new ("game03", "Kamen Rider BattrideWar Sousei" , "RGB" , 19.99M, new(2012,12,12))
    ]; //readonly -> You cannot assign different list to this list after initialization

    public static void MapGamesEndpoints(this WebApplication app)
    {
        //Extension method, this allow you to call this method with WebApplication class. You can call it by the instance of the target class
        //Syntax: methodName(this ClassName instance, other parameters) { ... }
        //Note: 1. You can only have 1 this parameter, and it must be the first parameter
        //Note: 2. Extension method must be static
        // GET /games
        //ASP.NET automatically serializes the DTO object into JSON format. You don't need to do it manually


        //Defining APi Router Groups -> You can make this easy to maintain without repeat /games or /api too much
        var ApiGroup = app.MapGroup("/api");
        var group = ApiGroup.MapGroup("/games");
        group.MapGet("/", () => games);
        // GET /games/1
        group.MapGet("/{id}", (string id) =>
        {
            var game = games.Find(game => game.ID == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        }).WithName("GetGame");

        //POST - Instead of calling 
        var newGame = new CreateGameDto()
        {
            Name = "One Piece", Genre = "Adventure", Price = 19.99M, ReleaseDate = new(2009, 12, 12) 
        };
        group.MapPost("", (CreateGameDto newGame) =>
        {
            GameDto game = new(
                "game04", newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate
            );
            games.Add(game);
            for (int i = 0; i < games.Count; ++i)
                Console.WriteLine(games[i]);
            // return Results.CreatedAtRoute("GetGame", new { id = game.ID }, game);
            return Results.Created("/games/game04", game);
        });
        //Run the application 
        //PUT /games/{id}
        Func<string, UpdateGameDto, IResult> UpdateGameHandler = (string id, UpdateGameDto data) =>
        {
            GameDto? game = games.Find((game) => game.ID == id);
            if (game is null)
                return Results.NotFound("Game cannot be found");
            if (data.Name is not null) game.Name = data.Name;
            if (data.Genre is not null) game.Genre = data.Genre;
            if (data.Price is not null && data.Price.HasValue) game.Price = data.Price.Value;
            if (data.ReleaseDate is not null && data.ReleaseDate.HasValue) game.ReleaseDate = data.ReleaseDate.Value;
            return Results.Ok(game);
        };
        group.MapPut("/{id}", UpdateGameHandler);
        Func<string, IResult> DeleteHandler = (string id) =>
        {
            int index = games.FindIndex(game => game.ID == id);
            if (index == -1)
            {
                return Results.NoContent();
            }
            games.RemoveAt(index);
            return Results.Ok("Ok");
        };
        group.MapDelete("/{id}", DeleteHandler);
    }
}
//static class meaning you cannot create an instance from this class. Everything in this static class must be a static field or method 
//Yes, static class is very funny, do you see it? 

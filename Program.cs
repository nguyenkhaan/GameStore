//VSCode Extensions: C# dev kit, C# Dev Tools
using GameStore.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
const string EndpointName = "GetGame"; 
// GET /games
List<GameDto> games = [
    new("game01" , "Street Fighter" , "Combat", 12.12M, new(2010, 10, 1)),
    new("game02", "Final Fantasy Report", "Fantasy", 12.99M, new(2010,10,10)),
    new ("game03", "Kamen Rider BattrideWar Sousei" , "RGB" , 19.99M, new(2012,12,12))
];
//ASP.NET automatically serializes the DTO object into JSON format. You don't need to do it manually
app.MapGet("/games", () => games);
// GET /games/1
app.MapGet("/games/{id}", (string id) =>
{
    var game = games.Find(game => game.ID == id);

    return game is null ? Results.NotFound() : Results.Ok(game);
}).WithName("GetGame");

//POST 
var newGame = new CreateGameDto()
{
    Name = "One Piece", Genre = "Adventure", Price = 19.99M, ReleaseDate = new(2009, 12, 12) 
};
app.MapPost("/games", (CreateGameDto newGame) =>
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
app.MapPut("/games/{id}", UpdateGameHandler);
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
app.MapDelete("/games/{id}", DeleteHandler);
app.Run();


/* 
How can we return response to client 
- We can use Results object to wrap result dto. Then turn it to the client 
*Some methods*: 
- Results.Ok(game);
- Results.Created(api_endpoint, game); -> This requires because in standard API, when we created a new resource, we have to adding 
a Location to the response's header, tell the client where they can get this new resource.
- Results.NoContent();
- Results.BadRequest(); 
- Results.NotFound(); 
- Results.UnAuthorized();
- Results.Forbid();
*/ 
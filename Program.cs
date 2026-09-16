//VSCode Extensions: C# dev kit, C# Dev Tools
using GameStore.Dtos;
using GameStore.Endpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Now, you can call the extension method with the instance of app class
app.MapGamesEndpoints();

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
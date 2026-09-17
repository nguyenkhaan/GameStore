//VSCode Extensions: C# dev kit, C# Dev Tools
using GameStore.Data;
using GameStore.Dtos;
using GameStore.Endpoints;
using GameStore.Models;
using GameStore.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

//Register the validation service to validate input for our API endpoints
//We use builder because it is an variable that store application configuration for services, environments

builder.Services.AddValidation();
builder.Services.AddControllers();

//Dependency Injection
builder.Services.AddScoped<GameService>(); //Everytime a GameService is initialize, the c# will handle it for you

var databaseConnection = builder.Configuration["ConnectionStrings:DefaultConnection"]; //loading .env from appsettings.json. You can put the .env here and don't commit it to github
builder.Services.AddNpgsql<GameStoreContext>(
    databaseConnection,
    //Pass by keywords to function parameters
    optionsAction: options => options.UseSeeding((context, _) =>
    {
        if (!context.Set<Genre>().Any())
        {
            //An anonymous object array. We cannot use List because List (collection generic) requires a specific type. 
            var genreElements = new[] {
                new { Id = "id01", Name = "Fighting" },
                new { Id = "id02", Name = "RPG" },
                new { Id = "id03", Name = "Action" }
            };
            context.Set<Genre>().AddRange(
                genreElements.Select(element => new Genre
                {
                    Id = element.Id,
                    Name = element.Name
                })
            );
        }
        if (!context.Set<Game>().Any())
        {
            var gameElements = new[]
            {
                new
                {
                    Id = "id01",
                    Name = "Kamen Rider Battiride War",
                    Price = 10.09M,
                    ReleaseDate = new DateOnly(2006, 10, 10),
                    genreId = "id01"
                },

                new
                {
                    Id = "id02",
                    Name = "The Legend of Zelda",
                    Price = 59.99M,
                    ReleaseDate = new DateOnly(2017, 3, 3),
                    genreId = "id02"
                },

                new
                {
                    Id = "id03",
                    Name = "Monster Hunter Rise",
                    Price = 39.99M,
                    ReleaseDate = new DateOnly(2021, 3, 26),
                    genreId = "id03"
                }
            };
            context.Set<Game>().AddRange(
                gameElements.Select(element => new Game
                {
                    Id = element.Id,
                    Name = element.Name,
                    GenreId = element.genreId,
                    Price = element.Price,
                    ReleaseDate = element.ReleaseDate
                })
            );
        }
        //Saving data to database
        context.SaveChanges();
    })
); //Connect to the database with connection string
Console.WriteLine("Database has been connected");

var app = builder.Build();

//Now, you can call the extension method with the instance of app class
// app.MapGamesEndpoints(); -- This is a minimal API, we will change to controller real 
app.MapControllers();
//You can install Nuget packages here: https://www.nuget.org/. In this page, you can search package and choose the suitable version for your .NET

//Migrate Automatically 
//app.MigrateDb(); //Calling the migration function -> This will run migrate automatically when the application start -> This should uncomment if you want the seeding run.



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

/*
Create database migration: 
Dontet install: dotnet tool install --local dotnet-ef --version 10.0.11 (Nuget package)
Dotnet design package: dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.0.10
- Create migration command: dotnet ef migrations add InitialCreate --output-dir Data/Migrations
- Apply migration command: dotnet database update -> Yeah it's too easy
*/
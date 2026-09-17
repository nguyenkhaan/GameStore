//VSCode Extensions: C# dev kit, C# Dev Tools
using GameStore.Data;
using GameStore.Dtos;
using GameStore.Endpoints;
using GameStore.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
//Register the validation service to validate input for our API endpoints
//We use builder because it is an variable that store application configuration for services, environments

builder.Services.AddValidation();
var databaseConnection = builder.Configuration["ConnectionStrings:DefaultConnection"]; //loading .env from appsettings.json. You can put the .env here and don't commit it to github
builder.Services.AddNpgsql<GameStoreContext>(databaseConnection); //Connect to the database with connection string
Console.WriteLine("Database has been connected");

var app = builder.Build();

//Now, you can call the extension method with the instance of app class
app.MapGamesEndpoints();
//You can install Nuget packages here: https://www.nuget.org/. In this page, you can search package and choose the suitable version for your .NET

//Migrate Automatically 
app.MigrateDb(); //Calling the migration function -> This will run migrate automatically when the application start



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
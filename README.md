# Dotnet Noodles

![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-512BD4?logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity%20Framework%20Core-10.0-512BD4?logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Database-4169E1?logo=postgresql&logoColor=white)

Dotnet Noodles is a small game catalog API built while learning C# and .NET. It includes controllers, DTOs, dependency injection, validation, Entity Framework Core, database migrations, and sample game data.

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- A running PostgreSQL database

### Run the project

1. Set the database connection string used by the application:

   ```bash
   dotnet user-secrets init
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=gamestore;Username=postgres;Password=your-password"
   ```

2. Restore dependencies and start the API:

   ```bash
   dotnet restore
   dotnet run
   ```

The API will print its local URL when it starts. Use that URL to try the game endpoints.

## Useful commands

```bash
dotnet build
dotnet ef migrations add MigrationName --output-dir Data/Migrations
dotnet ef database update
```

## C# Basic Courses 

If you are new to C# or wanna learn its concept. Give me one start, then visit `docs/` folder to enjoy a simple course. Thank you your supports. 

Build with Cloudian 💙 Cloud  


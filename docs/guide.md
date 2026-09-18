# ASP.NET Core: A Tour of .NET

## 1. Start Your Application

Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0). It includes the tools needed to build applications and the .NET and ASP.NET Core runtimes needed to run them locally. On Arch Linux, check the [Arch .NET package guidance](https://wiki.archlinux.org/title/.NET) for the SDK package matching .NET 10; package names and versions can change.

Check the SDK with `dotnet --version`. To create a separate ASP.NET Core project:

```bash
dotnet new web -n GameStorePractice --framework net10.0
cd GameStorePractice
dotnet run
```

`dotnet new console` creates a console application, not an ASP.NET Core web application. For the existing GameStore repository, run commands from the folder containing `GameStore.csproj` instead of creating another project.

For VS Code, install the C# Dev Kit extension for C# editing and debugging.

The web template uses `WebApplication.CreateBuilder(args)` to load default configuration and prepare logging and services. Add service registrations and configuration before calling `builder.Build()`. `Build()` creates the `WebApplication`; it does not reset your settings to defaults.

Register routes or controllers on the application to define how requests are handled, then call `app.Run()` to start the server. This project's `Program.cs` uses `AddControllers()` before building and `MapControllers()` afterward.

### Files and Folders to Notice

- `Properties/launchSettings.json`: local launch profiles, including application URLs and environment variables. This project's HTTP profile uses `http://localhost:5159`; its HTTPS profile uses `https://localhost:7278` and `http://localhost:5246`. These profiles are local development settings, not production configuration.
- `bin/`: build output, such as application assemblies (`.dll` files), runtime configuration, and dependencies.
- `obj/`: intermediate build and restore output, such as generated source, caches, and NuGet assets. It is not a collection of one native object file per C# source file; .NET builds normally produce assemblies rather than using that model.

See [ASP.NET Core fundamentals](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-10.0) and [`dotnet build`](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-build).

### Build and Run the Application

1. Run `dotnet build` from the project folder to compile the application. Depending on your editor setup, a build command may also be available in its interface.
2. Run `dotnet run` to build and start it. Use the listening URL printed in the terminal.

The remaining headings outline planned lessons; their content has not been written yet.

## 2. Understand REST APIs

## 3. Implement CRUD Endpoints

## 4. DTOs

## 5. Extension Methods

## 6. Route Groups

## 7. Handle Invalid Inputs

## 8. Entity Framework Core

## 9. Configuration System

## 10. Dependency Injection

## 11. Service Lifetimes

## 12. Map Entities to DTOs

## 13. Asynchronous Programming

## 14. Frontend Integration

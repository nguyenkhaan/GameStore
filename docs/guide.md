# ASP.NET. A TOUR AROUND MICROSOFT 
## 1. Start your Application 
Install .NET SDK: 

```bash
sudo pacman -S dotnet-sdk 
sudo pacman -S dotnet-runtime 
sudo pacman -S aspnet-runtime 
sudo pacman -S aspnet-targeting-pack
```
You can check: `dotnet --version`
`dotnet new console -n GameStore`

Configure VSCode for .NET development 

We use the builder pattern to define many things for our applications, from: configurations, services, a bunch of things for our application. All these things we will be set to default by build() method

Define how the HTTP request will be handle when it arrives to our application

### We have some files to notice:

- launchSetting.json (application's profile) -> define application url
(http://localhost:5159;http://localhost:5246), environment variables...
- bin: holds binary files, which are the actual executable code for your application
or library
- obj: intermediate files, compiled binary files that haven't linked yet (before DDL).
They're essentially fragments that will be combined to procedure the final executable.
The compiler generates one object file for each source file, and those files are placed into
obj folder.

You can read more here: https://stackoverflow.com/questions/5308491/what-are-the-obj-and-bin-folders-created-by-visual-studio-used-for

### How to build and run the application

1. Right Click onto the GameStore Project. You will see the build option in control panel. Let's click it
   or you can use command: `dotnet build`
2. You can use: `dotnet run` to run this project

## 2. Understand RESTAPI 

## 3. Implement CRUD endpoints 

## 4. DTO 

## 5. Extension Methods 

## 6. Route Groups 

## 7. Handle Invalid Inputs 

## 8. Entity Framework Core 

## 9. Configuration System 

## 10. Dependency Injection 

## 11. Service Lifetime 

## 12. Mapping Entities to DTO 

## 13. Asynchronus Programming 

## 14. FE Intergration 
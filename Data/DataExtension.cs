using GameStore.Models;
using Microsoft.EntityFrameworkCore;
namespace GameStore.Data;

public static class DataExtension
{
    public static void MigrateDb(this WebApplication app)
    {
        //scope 
        //Create a scope variable that will automatically dispose when out of scope
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }
}

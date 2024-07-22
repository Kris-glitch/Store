using Microsoft.EntityFrameworkCore;

namespace MorphoStore.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<JewleryStoreContext>();
        await dbContext.Database.MigrateAsync();
    }
}

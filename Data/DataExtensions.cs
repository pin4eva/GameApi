
using GameApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GameApi.Data;

public static class DataExtensions
{
    public static void InitializedDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbContext.Database.Migrate();
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GameStoreContext>(connString).AddScoped<IGameRepository, EntityFrameworkGameRepository>();

        return services;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApi.Entities;

namespace GameApi.Endpoints;

public static class GameEndpoints
{
    public static List<Game> games = new()
{
new Game(){Id=1, Name="Street Fighter II", Genre="Fighting",Price=19.99M,ReleaseDate= new DateTime(2022, 1, 1),ImageUrl="https://placeholder.co/100"},
new Game(){Id=2, Name="Final Fantacy XIV", Genre="RolePlaying",Price=69.99M,ReleaseDate= new DateTime(2010, 9, 3),ImageUrl="https://placeholder.co/100"},
new Game(){Id=3, Name="FIFA 23", Genre="Fighting",Price=19.99M,ReleaseDate= new DateTime(2022, 9, 27),ImageUrl="https://placeholder.co/100"},
};

    public static RouteGroupBuilder MapGameEndpoints(this IEndpointRouteBuilder route)
    {



        var gameRoute = route.MapGroup("/games").WithParameterValidation();

        gameRoute.MapGet("", () => games);
        gameRoute.MapGet("/{id}", (int id) => games.Find(game => game.Id == id));
        gameRoute.MapPost("", (Game game) =>
        {
            game.Id = games.Max(game => game.Id) + 1;

            games.Add(game);
            return games;
        });

        gameRoute.MapPut("/{id}", (int id, Game game) =>
        {
            Game? existingGame = games.Find(game => game.Id == id);
            if (existingGame is null) return Results.NotFound("Game not found");

            existingGame.Name = game.Name;
            existingGame.Price = game.Price;
            existingGame.ImageUrl = game.ImageUrl;
            existingGame.ReleaseDate = game.ReleaseDate;

            return Results.Ok(game);
        });

        gameRoute.MapDelete("/{id}", (int id) =>
        {
            Game? game = games.Find(game => game.Id == id);
            if (game is null) return Results.NotFound("game not found");
            games.Remove(game);
            return Results.Ok(game);
        });

        return gameRoute;
    }
}

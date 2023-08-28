using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApi.Entities;
using GameApi.Repositories;

namespace GameApi.Endpoints;

public static class GameEndpoints
{


    public static RouteGroupBuilder MapGameEndpoints(this IEndpointRouteBuilder route)
    {
        InMemoryRepository repository = new();


        var gameRoute = route.MapGroup("/games").WithParameterValidation();

        gameRoute.MapGet("", () => repository.GetGames());
        gameRoute.MapGet("/{id}", (int id) => repository.GetGame(id));
        gameRoute.MapPost("", (Game game) =>
        {
            return repository.CreateGame(game);
        });

        gameRoute.MapPut("/", (Game game) =>
        {
            Game? existingGame = repository.GetGame(game.Id);
            if (game is null)
            {
                return null;
            }
            else
            {
                var newGame = repository.UpdateGame(game);
                return newGame;

            }


        });

        gameRoute.MapDelete("/{id}", (int id) =>
        {
            Game? game = repository.GetGame(id);
            if (game is null) return Results.NotFound("game not found");
            repository.DeleteGame(id);
            return Results.Ok(game);
        });

        return gameRoute;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameApi.Dtos;
using GameApi.Entities;
using GameApi.Entities.Extension;
using GameApi.Repositories;

namespace GameApi.Endpoints;

public static class GameEndpoints
{


    public static RouteGroupBuilder MapGameEndpoints(this IEndpointRouteBuilder route)
    {



        var gameRoute = route.MapGroup("/games").WithParameterValidation();

        gameRoute.MapGet("", (IGameRepository repository) => repository.GetAll().Select(game => game.AsDto()));
        gameRoute.MapGet("/{id}", (IGameRepository repository, int id) => repository.Get(id)?.AsDto());
        gameRoute.MapPost("", (IGameRepository repository, CreateGameDTO gameDTO) =>
        {
            Game game = new()
            {
                Name = gameDTO.Name,
                ImageUrl = gameDTO.ImageUrl,
                Price = gameDTO.Price,
                ReleaseDate = gameDTO.ReleaseDate,
                Genre = gameDTO.Genre,
            };
            return repository.Create(game);
        });

        gameRoute.MapPut("/", (IGameRepository repository, UpdateGameDTO updatedGameDTO) =>
        {
            Game? existingGame = repository.Get(updatedGameDTO.Id);
            if (existingGame is null)
            {
                return null;
            }
            else
            {
                Game game = new()
                {
                    Id = existingGame.Id,
                    Name = updatedGameDTO.Name,
                    ImageUrl = updatedGameDTO.ImageUrl,
                    Price = updatedGameDTO.Price,
                    ReleaseDate = updatedGameDTO.ReleaseDate,
                    Genre = updatedGameDTO.Genre,
                };
                var newGame = repository.Update(game);
                return newGame;

            }


        });

        gameRoute.MapDelete("/{id}", (IGameRepository repository, int id) =>
        {
            Game? game = repository.Get(id);
            if (game is null) return Results.NotFound("game not found");
            repository.Delete(id);
            return Results.Ok(game);
        });

        return gameRoute;
    }
}

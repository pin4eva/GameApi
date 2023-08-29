using GameApi.Dtos;

namespace GameApi.Entities.Extension;

public static class EntityExtension
{
    public static GameDTO AsDto(this Game game)
    {
        return new GameDTO(
        game.Id,
        game.Name,
        game.Genre,
        game.ImageUrl,
        game.Price,
        game.ReleaseDate
        );
    }
}

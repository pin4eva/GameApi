using System.ComponentModel.DataAnnotations;

namespace GameApi.Dtos;

public record GameDTO(
int Id,
string Name,
string Genre,
string ImageUrl,
decimal Price,
DateTime ReleaseDate
);


public record CreateGameDTO(
[Required][StringLength(50)] string Name,
[Required][StringLength(20)] string Genre,
[Required][Url][StringLength(150)]
string ImageUrl,
[Range(1, 100)] decimal Price,
DateTime ReleaseDate
);

public record UpdateGameDTO(
int Id,
string Name,
string Genre,
string ImageUrl,
decimal Price,
DateTime ReleaseDate
);

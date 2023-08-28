using GameApi.Entities;


namespace GameApi.Repositories;

public class InMemoryRepository
{
    static readonly List<Game> games = new()
{
new Game(){Id=1, Name="Street Fighter II", Genre="Fighting",Price=19.99M,ReleaseDate= new DateTime(2022, 1, 1),ImageUrl="https://placeholder.co/100"},
new Game(){Id=2, Name="Final Fantacy XIV", Genre="RolePlaying",Price=69.99M,ReleaseDate= new DateTime(2010, 9, 3),ImageUrl="https://placeholder.co/100"},
new Game(){Id=3, Name="FIFA 23", Genre="Fighting",Price=19.99M,ReleaseDate= new DateTime(2022, 9, 27),ImageUrl="https://placeholder.co/100"},
};

    public IEnumerable<Game> GetGames()
    {
        return games;
    }

    public Game? GetGame(int id)
    {
        Game? game = games.SingleOrDefault(game => game.Id == id);
        return game;
    }

    public Game CreateGame(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
        return game;
    }

    public Game UpdateGame(Game game)
    {
        var index = games.FindIndex(x => x.Id == game.Id);
        games[index] = game;
        return game;
    }

    public Game? DeleteGame(int id)
    {
        Game? game = games.Find(game => game.Id == id);
        if (game is not null) games.Remove(game);

        return game;

    }
}

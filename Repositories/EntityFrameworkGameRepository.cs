
using GameApi.Data;
using GameApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameApi.Repositories;

public class EntityFrameworkGameRepository : IGameRepository
{

    private readonly GameStoreContext dbContext;

    public EntityFrameworkGameRepository(GameStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public IEnumerable<Game> GetAll()
    {
        return dbContext.Games.AsNoTracking().ToList();
    }


    public Game? Get(int id)
    {
        return dbContext.Games.Find(id);
    }

    public Game Create(Game game)
    {
        dbContext.Games.Add(game);
        dbContext.SaveChanges();

        return game;
    }


    public Game Update(Game game)
    {
        dbContext.Update(game);
        dbContext.SaveChanges();

        return game;
    }

    public Game? Delete(int id)
    {
        var game = dbContext.Games.Find(id);

        dbContext.Games.Where(game => game.Id == id).ExecuteDelete();

        return game;

    }
}

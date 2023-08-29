using GameApi.Entities;


namespace GameApi.Repositories;

public interface IGameRepository
{
  Game Create(Game game);
  Game? Delete(int id);
  Game Update(Game game);
  Game? Get(int id);

  IEnumerable<Game> GetAll();

};

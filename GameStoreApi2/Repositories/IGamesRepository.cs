using GameStoreApi2.Entities;

namespace GameStoreApi2.Repositories
{
    public interface IGamesRepository{
        void Create(Game game);
        void Delete(int id);
        Game? Get(int id);
        IEnumerable<Game> GetAll();
        void Update(Game updatedGame);
    }
}
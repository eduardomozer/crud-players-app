using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CrudPlayersModel.Repositories
{
    //public interface IPlayerRepository
    //{
    //    void Create(Player player);
    //    List<Player> GetPlayers();
    //    Player GetById(int id);
    //    void Update(Player player);
    //    void Delete(int id);
    //}

    public class PlayerRepository : IGenericRepository<Player>
    {
        private crudplayersEntities Context = null;

        public PlayerRepository()
        {
            if (Context == null)
            {
                Context = new crudplayersEntities();
            }
        }

        public void Create(Player player)
        {
            Context.Players.Add(player);
            Context.SaveChanges();
        }

        public Player GetById(int id)
        {
            return Context.Players.Where(p => p.Id == id).SingleOrDefault();
        }

        public List<Player> GetAll()
        {
            return Context.Players.ToList();
        }

        public void Update(Player player)
        {
            Context.Entry(player).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Player player = Context.Players.Where(p => p.Id == id).SingleOrDefault();
            Context.Players.Remove(player);
            Context.SaveChanges();
        }
    }
}
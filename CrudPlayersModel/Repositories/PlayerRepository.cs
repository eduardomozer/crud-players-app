using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CrudPlayersModel.Repositories
{
    public interface IPlayerRepository
    {
        void CreatePlayer(Player player);
        List<Player> GetPlayers();
        Player GetPlayerById(int id);
        void UpdatePlayer(Player player);
        void DeletePlayer(int id);
    }

    public class PlayerRepository : IPlayerRepository
    {
        private crudplayersEntities Context = null;

        public PlayerRepository()
        {
            if (Context == null)
            {
                Context = new crudplayersEntities();
            }
        }

        public void CreatePlayer(Player player)
        {
            Context.Players.Add(player);
            Context.SaveChanges();
        }

        public Player GetPlayerById(int id)
        {
            return Context.Players.Where(p => p.Id == id).SingleOrDefault();
        }

        public List<Player> GetPlayers()
        {
            return Context.Players.ToList();
        }

        public void UpdatePlayer(Player player)
        {
            Context.Entry(player).State = EntityState.Modified;
            Context.SaveChanges();
        }

        public void DeletePlayer(int id)
        {
            Player player = Context.Players.Where(p => p.Id == id).SingleOrDefault();
            Context.Players.Remove(player);
            Context.SaveChanges();
        }
    }
}
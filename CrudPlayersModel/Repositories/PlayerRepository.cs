using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CrudPlayersModel.Repositories
{
    public class PlayerRepository : IGenericRepository<Player>
    {
        private crudplayersEntities _Context;
        private crudplayersEntities Context
        {
            get { return _Context ?? (_Context = new crudplayersEntities()); }
            set { _Context = value; }
        }

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
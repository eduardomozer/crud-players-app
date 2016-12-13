using System.Collections.Generic;

namespace CrudPlayersModel.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : new()
    {
        void Create(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity player);
        void Delete(int id);
    }
}
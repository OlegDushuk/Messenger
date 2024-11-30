namespace Messenger.DAL.Repositories.Interfaces;

public interface IRepository<TEntity>
{
  Task<TEntity?> Get(string id);
  Task<List<TEntity>> GetAll();
  Task Create(TEntity entity);
  Task Update(string id, TEntity newEntity);
  Task Delete(string id);
}
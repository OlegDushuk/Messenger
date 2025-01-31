using Messenger.DAL.Models;

namespace Messenger.DAL.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
  Task<User?> GetByEmail(string email);
  Task<User?> GetByUsername(string username);
}
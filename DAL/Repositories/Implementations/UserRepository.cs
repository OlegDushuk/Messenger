using Messenger.DAL.Models;
using Messenger.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DAL.Repositories.Implementations;

public class UserRepository : IUserRepository
{
  private readonly AppDbContext _db;

  public UserRepository(AppDbContext db)
  {
    _db = db;
  }

  public async Task<User?> Get(string id)
  {
    return await _db.Users.FindAsync(id);
  }

  public async Task<List<User>> GetAll()
  {
    return await _db.Users.ToListAsync();
  }

  public async Task Create(User entity)
  {
    _db.Users.Add(entity);
    await _db.SaveChangesAsync();
  }

  public async Task Update(string id, User newEntity)
  {
    var user = await _db.Users.FindAsync(id);
    if (user == null)
    {
      throw new KeyNotFoundException($"User with ID {id} not found.");
    }
    
    user.Email = newEntity.Email;
    user.Username = newEntity.Username;
    user.PasswordHash = newEntity.PasswordHash;
    user.Name = newEntity.Name;

    _db.Users.Update(user);
    await _db.SaveChangesAsync();
  }
  
  public async Task Delete(string id)
  {
    var user = await _db.Users.FindAsync(id);
    if (user == null)
    {
      throw new KeyNotFoundException($"User with ID {id} not found.");
    }

    _db.Users.Remove(user);
    await _db.SaveChangesAsync();
  }

  public async Task<User?> GetByEmail(string email)
  {
    return await _db.Users.FirstOrDefaultAsync(user => user.Email == email);
  }

  public async Task<User?> GetByUsername(string username)
  {
    return await _db.Users.FirstOrDefaultAsync(user => user.Username == username);
  }
}
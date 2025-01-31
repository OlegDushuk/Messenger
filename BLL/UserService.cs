using Messenger.BLL.Interfaces;
using Messenger.DAL.Models;
using Messenger.DAL.Repositories.Interfaces;

namespace Messenger.BLL;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;

  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }
  
  public async Task CreateUserAsync(string username, string email, string password)
  {
    if (string.IsNullOrEmpty(username) ||
        string.IsNullOrEmpty(email) ||
        string.IsNullOrEmpty(password))
      throw new Exception();
    
    var user = await _userRepository.GetByEmail(email);
    if (user != null)
      throw new Exception();
    
    user = await _userRepository.GetByUsername(username);
    if (user != null)
      throw new Exception();
    
    user = new User
    {
      Username = username,
      Email = email,
      PasswordHash = password
    };
    
    await _userRepository.Create(user);
  }
}
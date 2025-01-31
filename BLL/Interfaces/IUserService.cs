namespace Messenger.BLL.Interfaces;

public interface IUserService
{
  Task CreateUserAsync(string username, string email, string password);
}
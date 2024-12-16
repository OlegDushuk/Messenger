using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.DAL;

public static class DataAccessServiceCollectionExtensions
{
  public static IServiceCollection AddDataAccess(this IServiceCollection services,
    Action<DbContextOptionsBuilder>? optionsAction = null)
  {
    services.AddDbContext<AppDbContext>(optionsAction);

    return services;
  }
}
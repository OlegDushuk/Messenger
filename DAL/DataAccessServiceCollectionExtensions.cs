using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.DAL;

public static class DataAccessServiceCollectionExtensions
{
  public static IServiceCollection AddDataAccess(this IServiceCollection services, string? connectionString)
  {
    services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
    
    return services;
  }
}
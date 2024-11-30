using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Messenger.DAL;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var configuration = new ConfigurationBuilder()
      .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../API"))
      .AddJsonFile("appsettings.json")
      .Build();
    
    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    
    var connectionString = configuration.GetConnectionString("Db");
    optionsBuilder.UseSqlServer(connectionString);

    return new AppDbContext(optionsBuilder.Options);
  }
}
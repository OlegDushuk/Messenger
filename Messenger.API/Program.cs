using Messenger.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add DAL to dependency injection
var connectionString = builder.Configuration.GetConnectionString("Db");
builder.Services.AddDataAccess(connectionString);

var app = builder.Build();

app.Run();
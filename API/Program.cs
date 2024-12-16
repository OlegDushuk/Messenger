using Messenger.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DAL to dependency injection
var connectionString = builder.Configuration.GetConnectionString("Db");
builder.Services.AddDataAccess(optionsAction => optionsAction.UseSqlServer(connectionString));

var app = builder.Build();

app.Run();
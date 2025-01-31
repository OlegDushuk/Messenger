using Messenger.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DAL to dependencies
var connectionString = builder.Configuration.GetConnectionString("Db");
builder.Services.AddDataAccess(optionsAction => optionsAction.UseSqlServer(connectionString));



var app = builder.Build();

app.Run();
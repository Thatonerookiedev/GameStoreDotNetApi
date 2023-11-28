using GameStoreApi2.Endpoints;
using GameStoreApi2.Entities;
using GameStoreApi2.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IGamesRepository,InMemGamesRepository>();

var connString = builder.Configuration.GetConnectionString("GameStoreContext");

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();

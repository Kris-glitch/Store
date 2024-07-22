using MorphoStore.Data;
using MorphoStore.Endpoints;

var builder = WebApplication.CreateBuilder(args); 
var connString = builder.Configuration.GetConnectionString("JewleryStore");

builder.Services.AddSqlite<JewleryStoreContext>(connString);
var app = builder.Build();

app.MapJewleryEndpoints();
app.MapCategoryEndpoints();
app.MapCollectionEndpoints();

await app.MigrateDbAsync();

app.Run();

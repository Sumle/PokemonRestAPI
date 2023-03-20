using Microsoft.EntityFrameworkCore;
using PokemonRestAPI;
using PokemonRestAPI.Contexts;
using PokemonRestAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", policy => {policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();});
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

bool useSQL = true;
if (useSQL)
{
    var optionsBuilder = new DbContextOptionsBuilder<PokemonContext>();
    optionsBuilder.UseSqlServer(Secrets.ConnectionString);
    PokemonContext context = new PokemonContext(optionsBuilder.Options);
    builder.Services.AddSingleton<IPokemonsRepository>(new PokemonsRepositoryDB(context));
}
else
{
    builder.Services.AddSingleton<PokemonsRepository>(new PokemonsRepository());
}

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
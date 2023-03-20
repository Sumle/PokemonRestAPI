using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PokemonLibrary;

namespace PokemonRestAPI.Contexts
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) :base(options) { }

        public DbSet<Pokemon> pokemons { get; set; }
    }
}
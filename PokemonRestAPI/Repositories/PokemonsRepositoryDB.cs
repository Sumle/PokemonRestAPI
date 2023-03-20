using PokemonRestAPI.Contexts;
using PokemonLibrary;

namespace PokemonRestAPI.Repositories
{
    public class PokemonsRepositoryDB : IPokemonsRepository
    {
        private PokemonContext _context;

        public PokemonsRepositoryDB(PokemonContext context)
        {
            _context = context;
        }

        public Pokemon AddPokemon(Pokemon newPokemon)
        {
            newPokemon.Id = 0;
            _context.pokemons.Add(newPokemon);
            _context.SaveChanges();
            return newPokemon;
        }

        public Pokemon? DeletePokemon(int id)
        {
            Pokemon? pokemon = GetById(id);
            _context.pokemons.Remove(pokemon);
            _context.SaveChanges();
            return pokemon;
        }

        public List<Pokemon> GetAll()
        {
            return _context.pokemons.ToList();
        }

        public List<Pokemon> GetAll(string? namefilter, int? amount, int? minlevel, int? minpokedex)
        {
            List<Pokemon> result = _context.pokemons.ToList();
            if (namefilter != null)
            {
                result = result.FindAll(pokemon => pokemon.Name.Contains(namefilter, StringComparison.InvariantCultureIgnoreCase));
            }
            if (amount != null)
            {
                int castamount = (int)amount;
                return result.Take(castamount).ToList();
            }
            if (minlevel != null)
            {
                result = result.FindAll(pokemon => pokemon.Level > minlevel);
            }
            if (minpokedex != null)
            {
                result = result.FindAll(pokemon => pokemon.PokeDex > minpokedex);
            }
            return result;
        }

        public Pokemon? GetById(int id)
        {
            List<Pokemon> result = _context.pokemons.ToList();
            return result.Find(pokemon => pokemon.Id == id);
        }

        public Pokemon? UpdatePokemon(int id, Pokemon update)
        {
            Pokemon? upPokemon = GetById(id);
            _context.pokemons.Update(upPokemon);
            upPokemon.Name = update.Name;
            upPokemon.Level = update.Level;
            upPokemon.PokeDex = update.PokeDex;
            _context.SaveChanges();
            return upPokemon;
        }
    }
}

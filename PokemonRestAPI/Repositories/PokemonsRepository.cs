using PokemonLibrary;

namespace PokemonRestAPI.Repositories
{
    public class PokemonsRepository : IPokemonsRepository
    {
        private int _nextID;
        private List<Pokemon> _pokemons;

        public PokemonsRepository()
        {
            _nextID = 1;
            _pokemons = new List<Pokemon>()
            {
                new Pokemon() {Id = _nextID++, Name = "Pikachu", Level = 9999, PokeDex = 25},
                new Pokemon() {Id = _nextID++, Name = "Charmander", Level = 1000, PokeDex = 12},
                new Pokemon() {Id = _nextID++, Name = "Arbok", Level = 20, PokeDex = 80}
            };
        }

        public List<Pokemon> GetAll()
        {
            return _pokemons;
        }

        // gør dette til eksamen, for at kunne beskytte listen og andre ikke kan  "ændre" i listen - forklar til eksamen (beskytter)
        public List<Pokemon> GetAll(string? namefilter, int? amount, int? minlevel, int? minpokedex)
        {
            List<Pokemon> result = new List<Pokemon>(_pokemons);
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
            return _pokemons.Find(pokemon => pokemon.Id == id);
        }

        public Pokemon AddPokemon(Pokemon newPokemon)
        {
            newPokemon.Id = _nextID++;
            _pokemons.Add(newPokemon);
            newPokemon.Validate();
            return newPokemon;
        }

        public Pokemon? DeletePokemon(int id)
        {
            Pokemon? pokemon = GetById(id);
            if (pokemon == null) return null;
            _pokemons.Remove(pokemon);
            return pokemon;
        }

        public Pokemon? UpdatePokemon(int id, Pokemon update)
        {
            update.Validate();
            Pokemon? upPokemon = GetById(id);
            if (upPokemon == null)
            {
                return null;
            }
            upPokemon.Name = update.Name;
            upPokemon.Level = update.Level;
            upPokemon.PokeDex = update.PokeDex;
            return upPokemon;
        }
    }
}
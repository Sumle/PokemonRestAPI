using PokemonLibrary;

namespace PokemonRestAPI.Repositories
{
    public interface IPokemonsRepository
    {
        Pokemon AddPokemon(Pokemon newPokemon);
        Pokemon? DeletePokemon(int id);
        List<Pokemon> GetAll(string? namefilter, int? amount, int? minlevel, int? minpokedex);
        Pokemon? GetById(int id);
        Pokemon? UpdatePokemon(int id, Pokemon update);
    }
}
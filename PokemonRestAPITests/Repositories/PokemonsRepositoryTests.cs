using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonRestAPI.Models;
using PokemonRestAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRestAPI.Repositories.Tests
{
    [TestClass()]
    public class PokemonsRepositoryTests
    {
        PokemonsRepository repository = new PokemonsRepository();
        Pokemon pokemon = new Pokemon() { Id = 9, Name = "Pokemon", Level = 5, PokeDex = 1};

        //[TestMethod()]
        //public void PokemonsRepositoryTest()
        //{
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void GetAllTest()
        {
            List<Pokemon> pokemons = repository.GetAll();
            Assert.IsNotInstanceOfType(pokemons, typeof(Pokemon));
            Assert.AreEqual(pokemons.Count, 3);
            Assert.AreEqual(pokemons[0].Id, 1);
            Assert.AreEqual(pokemons[0].Name, "Pikachu");
            Assert.IsNotNull(pokemons);
            var idSet = new HashSet<int>();
            foreach (var pokemon in pokemons)
            {
                Assert.IsFalse(idSet.Contains(pokemon.Id));
                idSet.Add(pokemon.Id);
            }
        }

        [TestMethod()]
        public void AddPokemonTest()
        {
            repository.AddPokemon(pokemon);
            List<Pokemon> pokemons = repository.GetAll();
            Assert.AreEqual(4, pokemons.Count);
            Assert.AreEqual(pokemons[3].Id, 4);
            Assert.AreEqual(pokemons[3].Name, "Pokemon");
            Assert.AreEqual(pokemons[0].Name, "Pikachu");
            Assert.IsInstanceOfType(pokemons[3], typeof(Pokemon));
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            repository.GetById(1);
            List<Pokemon> pokemons = repository.GetAll();
            Assert.IsNotNull(pokemons);
            Assert.AreEqual(pokemons[0].Id, 1);
            Assert.IsNotInstanceOfType(pokemons, typeof(Pokemon));
        }

        [TestMethod()]
        public void DeletePokemonTest()
        {
            repository.DeletePokemon(2);
            List<Pokemon> pokemons = repository.GetAll();
            Assert.AreEqual(2, pokemons.Count);
            Pokemon? deletepok = repository.GetById(2);
            Assert.IsNotNull(2, deletepok?.Name);
        }

        [TestMethod()]
        public void UpdatePokemonTest()
        {
            repository.UpdatePokemon(2, pokemon);
            Pokemon? updatedpok = repository.GetById(2);
            Assert.AreEqual(pokemon.Name, updatedpok?.Name);
        }
    }
}
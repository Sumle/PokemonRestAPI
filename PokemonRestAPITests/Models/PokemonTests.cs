using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonRestAPI.Models.Tests
{
    [TestClass()]
    public class PokemonTests
    {
        Pokemon pokemon = new Pokemon() { Id = 1, Name = "Pikachu", Level = 99, PokeDex = 1 };
        Pokemon pokemonIdNegative = new Pokemon() { Id = -1, Name = "Pika", Level = 99, PokeDex = 1 };
        Pokemon pokemonNameNull = new Pokemon() { Id = 1, Name = null, Level = 99, PokeDex = 1 };
        Pokemon pokemonNameEmpty = new Pokemon() { Id = 1, Name = "", Level = 99, PokeDex = 1 };
        Pokemon pokemonLevelLow = new Pokemon() { Id = 1, Name = "Pikachu", Level = -1, PokeDex = 1 };
        Pokemon pokemonPokeDexPositive = new Pokemon() { Id = 1, Name = "Pikachu", Level = 5, PokeDex = -1 };

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.AreEqual(pokemon, pokemon);
        }

        [TestMethod()]
        public void ValidateIdTest()
        {
            pokemon.ValidateId();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pokemonIdNegative.ValidateId());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            pokemon.Validate();
            Assert.ThrowsException<ArgumentNullException>(() => pokemonNameNull.ValidateName());
            Assert.ThrowsException<ArgumentException>(() => pokemonNameEmpty.ValidateName());
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            pokemon.ValidateName();
            Assert.ThrowsException<ArgumentNullException> (() => pokemonNameNull.ValidateName());
            Assert.ThrowsException<ArgumentException> (() => pokemonNameEmpty.ValidateName());
        }

        [TestMethod()]
        public void ValidateLevelTest()
        {
            pokemon.ValidateLevel();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pokemonLevelLow.ValidateLevel());
        }

        [TestMethod()]
        public void ValidatePodeDexTest()
        {
            pokemon.ValidatePodeDex();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => pokemonPokeDexPositive.ValidatePodeDex());
        }
    }
}
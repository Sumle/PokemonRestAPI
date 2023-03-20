using System;

namespace PokemonLibrary
{
    public class Pokemon
    {
        public int Id { get; set; } //ikke 0
        public string? Name { get; set; } //ikke null, minimum længde 2
        public int Level { get; set; } //1-99
        public int PokeDex { get; set; } //positivt tal > 0

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(Pokemon)) return false;
            Pokemon pokemon = (Pokemon)obj;
            if (pokemon.Id != Id) return false;
            if (pokemon.Name != Name) return false;
            if (pokemon.Level != Level) return false;
            if (pokemon.PokeDex != PokeDex) return false;
            return true;
        }

        public void Validate()
        {
            ValidateName();
            ValidateLevel();
            ValidatePodeDex();
        }

        public void ValidateId()
        {
            if (Id < 0)
            {
                throw new ArgumentOutOfRangeException("Id is negative");
            }
        }

        public void ValidateName()
        {
            if (Name == null)
            {
                throw new ArgumentNullException("Name is null");
            }
            if (Name.Length <= 2) 
            {
                throw new ArgumentException("Name is empty");
            }
        }

        public void ValidateLevel()
        {
            if (Level < 0 || Level > 999)
            {
                throw new ArgumentOutOfRangeException("Level ain't right");
            }
        }

        public void ValidatePodeDex()
        {
            if (PokeDex < 0)
            {
                throw new ArgumentOutOfRangeException("PokeDex is negative");
            }
        }
    }
}
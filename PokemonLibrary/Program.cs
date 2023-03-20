namespace PokemonLibrary
{
    public class Pokemon
    {
        public int Id { get; set; } // ikke null
        public string? Name { get; set; } // ikke null, minimum længde 2
        public int Level { get; set; } // 1-99
        public int PokeDex { get; set; } // positivt > 0

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

        public override string ToString()
        {
            return $"Name: {Name} Level: {Level}";
        }

        public void Validate()
        {

        }
    }
}
using System.Collections.Generic;

namespace Iterator
{
    public class Trainer
    {
        public List<Pokemon> Pokemons = new List<Pokemon>();
        public void AddPokemon(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }
    }
}
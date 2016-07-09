using System.Collections.Generic;

namespace Iterator
{
    public class PokemonLeague
    {
        public List<Trainer> Trainers = new List<Trainer>();

        public void AddTrainer(string name, int pokemonsAmount)
        {
            var trainer = new Trainer();

            for (int i = 0; i < pokemonsAmount; i++)
            {
                trainer.AddPokemon(new Pokemon(name + i));
            }

            Trainers.Add(trainer);
        }
    }
}
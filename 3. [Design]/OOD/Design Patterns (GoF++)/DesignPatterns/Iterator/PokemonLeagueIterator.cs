using System;

namespace Iterator
{
    class PokemonLeagueIterator
    {

        private readonly PokemonLeague _league;
        private int _currentTrainer;
        private int _currentPokemon;

        public PokemonLeagueIterator(PokemonLeague league)
        {
            _league = league;
            _currentTrainer = 0;
            _currentPokemon = 0;
        }

        public bool HasNext()
        {
            if (_currentTrainer < _league.Trainers.Count) return true;
            if (_currentTrainer == _league.Trainers.Count - 1)
                if (_currentPokemon < _league.Trainers[_currentTrainer].Pokemons.Count)
                    return true;

            return false;
        }

        public Pokemon First()
        {
            return _league.Trainers[0].Pokemons[0];
        }

        public Pokemon CurrentSoldier()
        {
            return _league.Trainers[_currentTrainer].Pokemons[_currentPokemon];
        }

        public Pokemon Next()
        {
            if (_currentTrainer < _league.Trainers.Count)
            {
                if (_currentPokemon < _league.Trainers[_currentTrainer].Pokemons.Count)
                {
                    _currentPokemon++;
                }
                else
                {
                    _currentPokemon = 0;
                    _currentTrainer++;
                    Next();
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return CurrentSoldier();
        }

    }
}
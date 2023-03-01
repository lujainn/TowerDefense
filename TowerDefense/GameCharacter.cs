using System;
namespace TowerDefense
{
    //Game character class applied to any object that gets placed on a tile and has health 
	public abstract class GameCharacter
	{
        public Tile CurrentTile { get; protected set; }
        public int Health { get; protected set; }
        public bool IsAlive { get; protected set; }
        public char Symbol { get; protected set; }

        protected GameCharacter( int health)
        {
            Health = health;
            IsAlive = true;
        }

        public void SetTile(Tile newTile)
        {
            CurrentTile = newTile;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                IsAlive = false;
            }
        }

        public void SetSymbol(char symbol)
        {
            Symbol = symbol;
        }

        public char GetSymbol()
        {
           return Symbol;
        }


    }
}


using System;
namespace TowerDefense
{
    //Tile class holds a single game character and preforms all tile opperations 
	public class Tile
	{
        public Vector2Int Position { get; private set; }
		public bool IsOccupied { get; private set; }

        public TileType Type { get; set; }
        public char Symbol { get;  private set; }

        private GameCharacter currentCharacter { get; set; }

        public Tile(Vector2Int position)
        {
            Position = position;
            Type = TileType.TowerTile;
            Symbol = '.';
        }

        public void SetEnemyPath()
        {
            Type = TileType.EnemyTile;

            Symbol = '-';

        }
        public void ResetSymbol()
        {
            if (Type == TileType.EnemyTile)
            {
                Symbol = '_';
            }
            else
            {
                Symbol = '.';
            }
            IsOccupied = false;
        }

        public void PlaceObject(GameCharacter character)
        {
            currentCharacter = character;
            currentCharacter.SetTile( this);
            IsOccupied = true;
            Symbol = character.Symbol;
        }

        public double EuclideanDistanceTo(Tile otherTile)
        {
            return Math.Sqrt(Math.Pow(Position.x - otherTile.Position.x, 2) + Math.Pow(Position.x - otherTile.Position.x, 2));
        }


        public GameCharacter GetCurrentCharacter()
        {
            return currentCharacter;
        }

        public enum TileType
		{
			EnemyTile,
			TowerTile
		}

        public void Print()
        {
            Console.Write(Symbol);
        }

    }
}


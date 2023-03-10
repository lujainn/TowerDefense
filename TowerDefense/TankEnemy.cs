using System;
namespace TowerDefense
{
    public class TankEnemy : GameCharacter, IMove
    {
        private int moveRate;
        private int moveRateCount;
        private readonly char tankEnemySymbol = 't';

        public TankEnemy(int health, int moveRate) : base(health)
        {
            this.moveRate = moveRate;
            moveRateCount = moveRate;
            SetSymbol(tankEnemySymbol);
        }

        public void Move(Tile newTile)
        {
            CurrentTile.ResetSymbol();
            CurrentTile = newTile;
            CurrentTile.PlaceObject(this);
        }

        public bool CanMove()
        {
            if (moveRateCount == 0)
            {
                moveRateCount = moveRate;
                return true;
            }
            else
            {
                moveRateCount -= 1;
                return false;
            }
        }
    }
}


using System;
namespace TowerDefense
{
    public class CannonTower : GameCharacter,IAttack
    {
        private int attackRadius;
        private int fireRate;
        private int fireRateCount;
        private int damage;
        private Board board;
        private readonly char canonTowerSymbol = 'C';

        public CannonTower(int health, int attackRadius, int fireRate, int damage, Board board) : base(health)
        {
            this.attackRadius = attackRadius;
            this.fireRate = fireRate;
            this.damage = damage;
            this.board = board;
            SetSymbol(canonTowerSymbol);
        }

        public void Attack(GameCharacter enemy)
        {
           
                enemy.TakeDamage(damage);
                List<Tile> tiles = board.GetTilesInRadius(enemy.CurrentTile,3);
            if (tiles != null)
            {
                foreach (Tile tile in tiles)
                {
                    if (tile.GetCurrentCharacter() != this && tile.GetCurrentCharacter() != null)
                    {
                        tile.GetCurrentCharacter().TakeDamage(damage);
                    }
                }
            }
                
            
        }

        public bool CanAttack()
        {
            if (fireRateCount == 0)
            {
                fireRateCount = fireRate;
                return true;
            }
            else
            {
                fireRateCount -= 1;
                return false;
            }
        }

        public int GetAttackRadius()
        {
            return attackRadius;
        }

    }
}


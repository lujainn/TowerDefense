using System;
namespace TowerDefense
{
    public class BombardTower : GameCharacter, IAttack
    {
        private int attackRadius;
        private int fireRate;
        private int fireRateCount;
        private int damage;
        private readonly char bombardTowerSymbol = 'B';

        public BombardTower(int health, int attackRadius, int fireRate, int damage) : base(health)
        {
            this.attackRadius = attackRadius;
            this.fireRate = fireRate;
            this.damage = damage;
            fireRateCount = fireRate;
            SetSymbol('B');
        }

        public void Attack(GameCharacter enemy)
        {
            
                enemy.TakeDamage(damage);
            
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


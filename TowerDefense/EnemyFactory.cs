using System;
namespace TowerDefense
{
    //Enemy class creates all tyoes of enemies
	public class EnemyFactory
	{
        private SlimeEnemy slimeEnemy { get; set; }
        private TankEnemy tankEnemy { get; set; }
        private ZombieEnemy zombieEnemy { get; set; }
        private Board Board { get; set; }


        public EnemyFactory(Board board)
		{
            Board = board;
		}

        public SlimeEnemy SpawnSlime()
        {
            slimeEnemy = new SlimeEnemy( 3, 1);
            return slimeEnemy;
        }

        public ZombieEnemy SpawnZombie()
        {
            zombieEnemy = new ZombieEnemy(10, 2);
            return zombieEnemy;
        }

        public TankEnemy SpawnTank()
        {
            tankEnemy = new TankEnemy(20, 3);
            return tankEnemy;
        }


    }
}


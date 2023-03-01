using System;
namespace TowerDefense
{
    //Factory class creates all the differnet kinds of towers
	public class TowerFactory
	{
		private AssaultTower assaultTower;
		private BombardTower bombardTower;
		private CannonTower cannonTower;
		private Board board;

		public TowerFactory(Board board)
		{
			this.board = board;
		}

		public AssaultTower SpawnAssaultTower()
		{
            assaultTower = new AssaultTower(3, 3, 3, 1);
            return assaultTower;
		}

        public BombardTower SpawnBombardTower()
        {
            bombardTower = new BombardTower(5, 4, 2, 2);
            return bombardTower;
        }

        public CannonTower SpawnCannonTower()
        {
            cannonTower = new CannonTower(1, 5, 3, 1, board);
            return cannonTower;
        }


    }
}


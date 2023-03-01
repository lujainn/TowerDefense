using System;
namespace TowerDefense
{
	public interface IMove
	{
        public void Move(Tile newtile);
        public bool CanMove();


    }
}


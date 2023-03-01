using System;
namespace TowerDefense
{
	public interface IAttack
	{
		bool CanAttack();
		void Attack(GameCharacter enemy);
		int GetAttackRadius();

    }
}


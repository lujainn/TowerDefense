using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense
{
    public class Game
    {
        public Vector2Int worldSize { get; private set; }

        private Board board;
        private EnemyFactory enemyFactory;
        private TowerFactory towerFactory;
        private List<GameCharacter> enemies;
        private List<GameCharacter> towers;
        private List<GameCharacter> deadEnemies;
        private Action gameEnded;


        public Game(Vector2Int worldSize, List<Vector2Int> enemyPath, Action onGameOver)
        {
            this.worldSize = worldSize;

            board = new Board(worldSize.x, worldSize.y, enemyPath);
            enemyFactory = new EnemyFactory(board);
            towerFactory = new TowerFactory(board);
            enemies = new List<GameCharacter>();
            towers = new List<GameCharacter>();
            deadEnemies = new List<GameCharacter>();
            gameEnded = onGameOver;

        }

        public void Update()
        {
            
           foreach (GameCharacter tower in towers)
           {
                    
                foreach (GameCharacter enemy in enemies)
                {
                    if (enemy is IMove movableEnemy && movableEnemy.CanMove())
                    {
                        if (enemy.IsAlive)
                        {
                            Tile nextTile = board.GetNextFreeEnemyTile(enemy.CurrentTile);
                            if (nextTile != null)
                            {
                                movableEnemy.Move(nextTile);
                            }
                        }
                        else
                        {
                            deadEnemies.Add(enemy);
                        }

                        if (tower is IAttack attacker && tower.IsAlive && attacker.CanAttack())
                        {
                            if (tower.CurrentTile.EuclideanDistanceTo(enemy.CurrentTile) <= attacker.GetAttackRadius())
                            {
                                attacker.Attack(enemy);
                                Console.WriteLine("The tower " + tower.Symbol + " has attacked enemy:" + enemy.Symbol);
                            }

                        }
                    }
                }
                    
                
            }

            foreach (GameCharacter corpse in deadEnemies)
            {
                Console.Write(corpse.Symbol + " has died :(");
                corpse.CurrentTile.ResetSymbol();
                enemies.Remove(corpse);
            }

            CheckIfGameEnded();

        }

        public void SpawnAssaultTower(Vector2Int position)
        {
            board.PlaceObjectOnTile(board.GetTile(position), towerFactory.SpawnAssaultTower());
            towers.Add(board.GetTile(position).GetCurrentCharacter());
        }
        public void SpawnBombardTower(Vector2Int position)
        {
            board.PlaceObjectOnTile(board.GetTile(position), towerFactory.SpawnBombardTower());
            towers.Add(board.GetTile(position).GetCurrentCharacter());
        }
        public void SpawnCannonTower(Vector2Int position)
        {
            board.PlaceObjectOnTile(board.GetTile(position), towerFactory.SpawnCannonTower());
            towers.Add(board.GetTile(position).GetCurrentCharacter());
        }


        public void SpawnSlime()
        {
            SlimeEnemy slimeEnemy = enemyFactory.SpawnSlime();
            board.PlaceObjectOnTile(board.GetStartingEnemyTile(), slimeEnemy);
            enemies.Add(slimeEnemy);
        }
        public void SpawnZombie()
        {
            ZombieEnemy zombieEnemy = enemyFactory.SpawnZombie();
            board.PlaceObjectOnTile(board.GetStartingEnemyTile(), zombieEnemy);
            enemies.Add(zombieEnemy);
        }
        public void SpawnTank()
        {
            TankEnemy tankEnemy = enemyFactory.SpawnTank();
            board.PlaceObjectOnTile(board.GetStartingEnemyTile(), tankEnemy);
            enemies.Add(tankEnemy);
        }

        public bool CanSpawnEnemy()
        {
            return board.StartingPointFree();
        }


        public char GetDisplayChar(Vector2Int position)
        {
            return board.GetTile(position).Symbol;
        }

        public void CheckIfGameEnded()
        {
            if (enemies.Count == 0|| board.EnemiesReached())
            {
                Console.WriteLine("Game Over");
               //gameEnded.Invoke();
            }
        }
    }
}

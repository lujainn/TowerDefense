using System;
using System.Collections.Generic;

namespace TowerDefense
{
    // Board class holds all the tiles and enemy  paths, it holds all nessasary tile operations

    public class Board
    {
        private Tile[,] tiles;
        private List<Tile> enemyPathTiles;

        public Board(int width, int height, List<Vector2Int> enemyPath)
        {
            tiles = new Tile[width, height];
            enemyPathTiles = new List<Tile>();

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(new Vector2Int(x, y));
                }
            }

            Vector2Int enemyTilePos;
            Tile enemyTile;

            for (int i = 0; i < enemyPath.Count; i++)
            {
                enemyTilePos = enemyPath[i];
                enemyTile = tiles[enemyTilePos.x, enemyTilePos.y];
                enemyTile.SetEnemyPath();
                enemyPathTiles.Add(enemyTile);
            }
        }


        public void PlaceObjectOnTile(Tile tile, GameCharacter character)
        {
            tiles[tile.Position.x, tile.Position.y].PlaceObject(character);
        }

        public Tile GetTile(Vector2Int position)
        {
            if (position.x < 0 || position.x >= tiles.GetLength(0) || position.y < 0 || position.y >= tiles.GetLength(1))
            {
                return null;
            }
            else
            {

                return tiles[position.x, position.y];
            }
        }

        public List<Tile> GetTilesInRadius(Tile tile, int radius)
        {
            List<Tile> tilesInRadius = new List<Tile>();

            for (int x = tile.Position.x - radius; x <= tile.Position.x + radius; x++)
            {
                for (int y = tile.Position.y - radius; y <= tile.Position.y + radius; y++)
                {
                    if (x >= 0 && x < tiles.GetLength(0) && y >= 0 && y < tiles.GetLength(1))
                    {
                        Tile currentTile = tiles[x, y];

                        if (tile.EuclideanDistanceTo(currentTile) <= radius)
                        {
                            tilesInRadius.Add(currentTile);
                        }
                    }
                }
            }

            return tilesInRadius;
        }

        public bool StartingPointFree()
        {
            return !GetStartingEnemyTile().IsOccupied;
        }

        public Tile GetStartingEnemyTile()
        {
            return enemyPathTiles[0];
        }

        public Tile GetNextFreeEnemyTile(Tile tile)
        {
            int currentIndex = enemyPathTiles.IndexOf(tile);
            for (int i = currentIndex + 1; i < enemyPathTiles.Count; i++)
            {
                Tile nextTile = enemyPathTiles[i];
                if (!nextTile.IsOccupied)
                {
                    return nextTile;
                }
            }
            return null;
        }

        public Tile GetEndingEnemyTile()
        {
            return enemyPathTiles[enemyPathTiles.Count - 1];
        }


        public void Print()
        {
            for (int y = 0; y < tiles.GetLength(1); y++)
            {
                for (int x = 0; x < tiles.GetLength(0); x++)
                {
                    tiles[x, y].Print();
                }
                Console.Out.Write('\n');
            }
        }

        public bool EnemiesReached()
        {
            return GetEndingEnemyTile().IsOccupied;

        }
    }
}

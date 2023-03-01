# Tower Defense in C# demo


# Solution created:
    In this solution, I kept Game and Program classes the way they are, I just commented out Console.Clear to show what happens better. I also commented out CheckIfGameEnded() in the game class out because it closed the terminal for me.
    In order to make this game expandable, I decided to a tile and board class to be able to control the game board better, this makes it easily expandable if say we want to have different paths for different characters, restricing movment and checking neigboring tiles. Tiles can show what character is on them, change the character, calculate distance between each other and other tile relates operations. The same with the board class, it holds all tiles and it also has the enemy path and will do any operations related to the path and tiles. I created a GameCharacter class that both Towers and Enemies inherhite since they all share the Health property, it also helps me sort all objects that get placed on tiles in one list with one type. Then each type of enemy has it's own class that also implements the IMove interface that moves an enemy from tile to another. The EnemyFactory then is responsible for creating all the different enemies' instances, this way I can expand my enemy types very easily and move them all the same way. I did the same with towers implementing an IAttack interface instead of IMove so that different towers can launch their attack. 


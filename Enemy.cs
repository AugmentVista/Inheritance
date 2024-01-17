using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Enemy : Entity
    {

        Program program;
        EntityActions actions;
        HealthSystem healthSystem;


        public Enemy()
        {
            program = new Program();
            actions = new EntityActions();
            healthSystem = new HealthSystem();
        }

        public int scoreValue;
        public int xpValue;
        public int goldDrop;
        public int remainingEnemies;
        public int MapWidth; 
        public int MapHeight;
        public char enemyCharacter = '♣';
        public int numberOfEnemies = 50;
        static Random random = new Random();


        
        public void EnemyPopulate()
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                int randomX, randomY;

                do
                {
                    randomX = random.Next(MapWidth - 1);
                    randomY = random.Next(MapHeight - 1);
                } while (map[randomY, randomX] != ' ' || map[randomY, randomX] == '☻' || (randomX < 8 && randomY < 8));
                map[randomY, randomX] = enemyCharacter;
            }
        }

        public void MoveEnemies()
        {
            MapWidth = map.GetLength(1);
            MapHeight = map.GetLength(0);
            for (int x = 0; x < 76; x++)
            {
                for (int y = 0; y < 27; y++)
                {
                    if (map?[y, x] == enemyCharacter)
                    {
                        int randomDirection = random.Next(4);

                        int newX = x, newY = y;
                        switch (randomDirection) // 0: Up, 1: Right, 2: Down, 3: Left
                        {
                            case 0: // Up
                                newX = Math.Max(0, x - 1);
                                break;
                            case 1: // Right
                                newY = Math.Min(MapHeight - 1, y + 1);
                                break;
                            case 2: // Down
                                newX = Math.Min(MapWidth - 1, x + 1);
                                break;
                            case 3: // Left
                                newY = Math.Max(0, y - 1);
                                break;
                        }
                        if (actions.playerRow == newX && actions.playerCol == newY)
                        {
                            healthSystem.TakeDamage(2);
                        }
                        else if (map[newY, newX] == ' ')
                        {
                            map[y, x] = ' ';
                            map[newY, newX] = enemyCharacter;
                        }
                    }
                }
            }
        }
        public int GetRemainingEnemies()
        {
            remainingEnemies = GetRemainingEnemies();
            int count = 0;

            for (int y = 0; y < MapHeight - 1; y++)
            {
                for (int x = 0; x < MapWidth - 1; x++)
                {
                    if (map?[y, x] == enemyCharacter)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class EntityActions : Entity
    {
        HealthSystem healthSystem;
        Enemy enemy;
        Player player;
        Program program;
        Item item;
        public int newRow = 0;
        public int newCol = 0;
        public int playerRow;
        public int playerCol;

        public EntityActions()
        { 
            healthSystem = new HealthSystem();
            enemy = new Enemy();
            player = new Player();
            program = new Program();
            item = new Item(); 
        }


        public string[] enviromentalHazard = new string[]
        {
          "⅛","⅜","⅝","⅞"
        };


        

        public bool IsValidMove(int newRow, int newCol)
        {
            if (newRow >= 0 && newRow < map.GetLength(1) && newCol >= 0 && newCol < map.GetLength(0))
            {
                switch (map[newCol, newRow])
                {
                    case ' ':
                    case '☻':
                    case '⅛':
                    case '⅜':
                    case '⅝':
                    case '⅞':
                        return true;
                    case '╭':
                    case '─':
                    case '╮':
                    case '╯':
                    case '╰':
                    case '│':
                    case '┘':
                    case '┌':
                    case '┐':
                    case '└':
                    case '├':
                    case '┤':
                    case '┬':
                    case '┴':
                        return false;
                }
                if (map[newCol, newRow] == enemy.enemyCharacter)
                {
                    map[newCol, newRow] = ' ';
                }
                if (map[newCol, newRow] == item.Fruit && healthSystem.health < healthSystem.maxHealth)
                {
                    map[newCol, newRow] = ' ';
                    healthSystem.GainHealth(10);
                }
            }
            return false;
        }

        public void MovePlayer(int rowChange, int columnChange)
        {
            
            Console.CursorVisible = false;
            playerRow = newRow + rowChange;
            playerCol = newCol + columnChange;

            if (IsValidMove(newRow, newCol))
            {
                playerRow = newRow;
                playerCol = newCol;

                if (enviromentalHazard.Contains(map?[playerCol, playerRow].ToString()))
                {
                    Random random = new Random();
                    int damageChance = random.Next(8);

                    switch (map?[playerCol, playerRow].ToString())
                    {
                        case "⅛":
                            if (damageChance == 0) // 1/8 probability
                            {
                                healthSystem.TakeDamage(2);
                            }
                            break;
                        case "⅜":
                            if (damageChance < 3) // 3/8 probability
                            {
                                healthSystem.TakeDamage(2);
                            }
                            break;
                        case "⅝":
                            if (damageChance < 5) // 5/8 probability
                            {
                                healthSystem.TakeDamage(2);
                            }
                            break;
                        case "⅞":
                            if (damageChance < 7) // 7/8 probability
                            {
                                healthSystem.TakeDamage(2);
                            }
                            break;
                    }
                }
            }
        }
        public void HandleKeyPress(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.DownArrow:
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.LeftArrow:
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.RightArrow:
                    MovePlayer(1, 0);
                    break;

                case ConsoleKey.W:
                    MovePlayer(0, -1);
                    break;

                case ConsoleKey.S:
                    MovePlayer(0, 1);
                    break;

                case ConsoleKey.A:
                    MovePlayer(-1, 0);
                    break;

                case ConsoleKey.D:
                    MovePlayer(1, 0);
                    break;
            }
            //Enemy.MoveEnemies();
            //Program.UpdateScore();
        }
    }
}

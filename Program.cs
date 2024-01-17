using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Program
    {
        Player player;
        HealthSystem healthSystem;
        Enemy enemy;
        EntityActions entityActions;
        MapBuffer mapBuffer;
        Item item;
        Stats stats = new Stats();


        public int scale;
        public char[,]? map;
        public int score;
        static string[] border = new string[]
        {
          "╔","╗","╝","╚", "║","═"
        };

        public Program()
        {
            healthSystem = new HealthSystem();
            player = new Player();
            enemy = new Enemy();
            entityActions = new EntityActions();
            mapBuffer = new MapBuffer();
            item = new Item();
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Stats stats = new Stats();
            Program program = new Program();
            Enemy enemy = new Enemy();
            EntityActions entityActions = new EntityActions();
            MapBuffer mapBuffer = new MapBuffer();
            Player player = new Player();

            stats.dead = false;
            program.TxtFileToMapArray();
            enemy.EnemyPopulate();
            ConsoleKeyInfo keyInfo;
                do
                {
                    keyInfo = Console.ReadKey(true);
                    Console.SetCursorPosition(0, 0);
                    entityActions.HandleKeyPress(keyInfo.Key);
                    program.DrawMap();
                    player.DrawPlayer();
                    mapBuffer.DisplayBuffer(1);
                    program.DrawBorder();
                } while (keyInfo.Key != ConsoleKey.Escape && !stats.dead); // end game when all enemies are ded'd 
        }

        void DrawBorder()
        {
            int mapWidth = map.GetLength(1);
            int mapHeight = map.GetLength(0);
            int HorizontalWall = 1;
            int VerticalWall = 1;
            int totalWidth = (mapWidth + 1);
            int totalHeight = (mapHeight + 1);

            foreach (string ASCll in border)
            {
                switch (ASCll)
                {
                    case "╔":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "╗":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "╝":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "╚":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "║":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case "═":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(border[0]);
            Console.SetCursorPosition(totalWidth, 0);
            Console.Write(border[1]);
            if (HorizontalWall >= totalWidth)
            {
                HorizontalWall = totalWidth;
            }
            if (VerticalWall >= totalHeight)
            {
                VerticalWall = totalHeight;
            }
            for (int i = 0; i < totalWidth; i++)
            {
                Console.SetCursorPosition(HorizontalWall, 0); // ceiling
                Console.Write(border[5]);
                Console.SetCursorPosition(HorizontalWall, totalHeight); // floor
                Console.Write(border[5]);
                HorizontalWall++;
            }
            for (int j = 0; j < totalHeight; j++)
            {
                Console.SetCursorPosition(0, VerticalWall); // lefthand wall 
                Console.Write(border[4]);
                Console.SetCursorPosition(totalWidth, VerticalWall); // righthand wall 
                Console.Write(border[4]);
                VerticalWall++;
            }
            Console.SetCursorPosition(totalWidth, 0);
            Console.Write(border[1]);
            Console.SetCursorPosition(0, totalHeight);
            Console.Write(border[3]);
            Console.SetCursorPosition(totalWidth, totalHeight);
            Console.Write(border[2]);
        }

        public void TxtFileToMapArray()
        {
            string[] lines = File.ReadAllLines("Map.txt");

            map = new char[lines.GetLength(0), lines[0].Length];
            mapBuffer.firstBuffer = new char[lines.GetLength(0), lines[0].Length];
            mapBuffer.secondBuffer = new char[lines.GetLength(0), lines[0].Length];
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }
        }
        public void LoadMap2()
        {
            string[] lines = File.ReadAllLines("Map2.txt");

            map = new char[lines.GetLength(0), lines[0].Length];
            mapBuffer.firstBuffer = new char[lines.GetLength(0), lines[0].Length];
            mapBuffer.secondBuffer = new char[lines.GetLength(0), lines[0].Length];
            for (int i = 0; i < lines.GetLength(0); i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }
        }

        public void DrawMap()
        {
            Array.Copy(map, mapBuffer.secondBuffer, map.Length);
        }

        

        public int GetCurrentFruit()
        {
            int totalFruit = 0;
            int MapWidth = map.GetLength(1);
            int MapHeight = map.GetLength(0);

            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (map[y, x] == item.Fruit)
                    {
                        totalFruit++;
                    }
                }
            }
            return totalFruit;
        }

        public int UpdateScore()
        {
            int score = enemy.numberOfEnemies - enemy.GetRemainingEnemies();
            stats.Score = score;
            return score;
        }


    }

}
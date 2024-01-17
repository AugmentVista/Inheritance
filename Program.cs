using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Program
    {
        Player player = new Player();
        static void Main(string[] args)
        {
            Console.WriteLine("Inheritance");
            Console.WriteLine("-----------");
            Console.WriteLine();
            Player player = new Player();
            Enemy enemy = new Enemy();
            Item item = new Item();

            player.healthSystem.health = 100;
            player.position.x = 0;
            player.position.y = 0;


            Console.ReadKey(true);
        }
    }

    public struct Point2D
    {
        public int x;
        public int y;
    } 
}
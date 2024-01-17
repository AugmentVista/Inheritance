using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class HealthSystem
    {
        public int health;
        public int maxHealth;
        public bool dead;

        public void GainHealth(int hp)
        {
            health++;

            if (health >= maxHealth)
            {
                health = maxHealth;
            }
        }
        public void TakeDamage(int hp)
        {
            health--;
            if (health <= 0)
            {
                Die();
            }
        }
        public void Die()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(" ███████████████████████████████████████   YOU DIED    ███████████████████████████████████████");
            Console.ReadKey(true);
            dead = true;
        }

    }
}

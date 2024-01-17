using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Entity
    {
        public HealthSystem healthSystem; 
        public float HP;
        public int ATK;
        public int DEF;
        public Point2D position;


        public Entity() 
        {
            healthSystem = new HealthSystem();
        }
        
    }
}

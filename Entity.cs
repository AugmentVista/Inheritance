using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Entity : Program
    {
        public float HP;
        public int ATK;
        public int DEF;
        Stats position = new Stats();
       

        void TestMethod()
        {
            position.column = 5;
            position.row = 5;
        }

        
    }
}

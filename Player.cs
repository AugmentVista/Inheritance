using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Player : Entity
    {

        MapBuffer mapBuffer;
        EntityActions entityActions;
        public char playerCharacter = '☻';
        public int XP;
        public int Level;
        public int Score;

        public Player()
        {
            mapBuffer = new MapBuffer();
            entityActions = new EntityActions();
        }

        public void DrawPlayer()
        {
            int playerCol = entityActions.playerCol = 4;
            int playerRow = entityActions.playerRow = 4;
            mapBuffer.secondBuffer[playerCol, playerRow] = playerCharacter;
        }
         
    }

}

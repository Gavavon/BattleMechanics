using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    class Healer : CharCreator
    {
        public override void defineChar(CharCreator temp)
        {
            int[] highStats = new int[] { 4, 3, 2 };
            int[] lowStats = new int[] { 0, 1, 2 };

            randomizeArray(highStats);
            randomizeArray(lowStats);

            temp.Attack = attackStats[lowStats[1]];
            temp.Speed = speedStats[highStats[1]];
            temp.Defense = defenseStats[lowStats[0]];
            temp.Health = healthStats[highStats[0]];
            temp.Class = "Healer";
            base.defineChar(temp);
        }

        /* Design Plan
         *
         *
         *
         */
    }
}

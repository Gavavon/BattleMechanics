using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    class Healer : CharCreator
    {
        public Healer()
        {
            int[] highStats = new int[] { 4, 3, 2 };
            int[] lowStats = new int[] { 0, 1, 2 };

            randomizeArray(highStats);
            randomizeArray(lowStats);

            this.Attack = attackStats[lowStats[1]];
            this.Speed = speedStats[highStats[1]];
            this.Defense = defenseStats[lowStats[0]];
            this.Health = healthStats[highStats[0]];
            this.Class = "Assassin";
        }

        /* Design Plan
         *
         *
         *
         */
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    class Healer : CharCreator
    {
        /// <summary>
        /// defineChar in the healer class is designed for defining stats for any assassin made
        /// temp is the object that is getting stats applied to it
        /// this method overrides the defineChar in the CharCreator class so it can recieve a ID
        /// </summary>
        /// <param name="temp"></param>
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
         * I will be refenseing the extra low, low, mid, high, and extra high preset stats. 
         * if you are confused on this please visit the params.cs file to see the interface.
         * 
         * the healer class has been implemented currently it is designed to be a bit of a worse fighter class.
         * However, the creation of the Action.cs method a healer could now heal during combat.
         * if you curious on the design of the classes a bit deeper read the design doc.
         *
         */
    }
}

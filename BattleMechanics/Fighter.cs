using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    /// <summary>
    /// the fighter class is designed to create fighters using the CharCreator object
    /// </summary>
    class Fighter : CharCreator
    {
        /// <summary>
        /// defineChar in the fighter class is designed for defining stats for any assassin made
        /// temp is the object that is getting stats applied to it
        /// this method overrides the defineChar in the CharCreator class so it can recieve a ID
        /// </summary>
        /// <param name="temp"></param>
        public override void defineChar(CharCreator temp)
        {
            int[] highStats = new int[] { 1, 2, 3 };
            int[] lowStats = new int[] { 1, 2, 3 };

            randomizeArray(highStats);
            randomizeArray(lowStats);

            temp.Attack = attackStats[highStats[0]];
            temp.Speed = speedStats[highStats[1]];
            temp.Defense = defenseStats[lowStats[0]];
            temp.Health = healthStats[lowStats[1]];
            temp.Class = "Fighter";
            base.defineChar(temp);
        }
    }

    /* Design Plan
     * I will be refenseing the extra low, low, mid, high, and extra high preset stats. 
     * if you are confused on this please visit the params.cs file to see the interface.
     * 
     * fighters are the replacement for the original healer class.
     * fighters are not capable of getting extra high or extra low in any field.
     * At this point i have not done extensive testing with this class against other classes.
     * However through the minimal testing the fighter fitting to be a balance between the two classes.
     */
}

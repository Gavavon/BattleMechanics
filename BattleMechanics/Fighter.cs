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
        /// the constructor assigns values to the stats of the CharCreator object
        /// it randomly generates fighter characters
        /// </summary>
        public Fighter()
        {
            int[] highStats = new int[] { 1, 2, 3 };
            int[] lowStats = new int[] { 1, 2, 3 };

            randomizeArray(highStats);
            randomizeArray(lowStats);

            this.Attack = attackStats[highStats[0]];
            this.Speed = speedStats[highStats[1]];
            this.Defense = defenseStats[lowStats[0]];
            this.Health = healthStats[lowStats[1]];
            this.Class = "Fighter";
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

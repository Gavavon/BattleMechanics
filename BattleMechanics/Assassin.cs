using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    /// <summary>
    /// the assassin class is designed to create assassins using the CharCreator object
    /// </summary>
    class Assassin : CharCreator
    {
        /// <summary>
        /// the constructor assigns values to the stats of the CharCreator object
        /// it randomly generates assassin characters
        /// </summary>
        public Assassin()
        {
            int[] highStats = new int[] { 4, 3, 2 };
            int[] lowStats = new int[] { 0, 1, 2 };

            randomizeArray(highStats);
            randomizeArray(lowStats);

            this.Attack = attackStats[highStats[0]];
            this.Speed = speedStats[highStats[1]];
            this.Defense = defenseStats[lowStats[0]];
            this.Health = healthStats[lowStats[1]];
            this.Class = "Assassin";
        }
    }
    /* Design Plan
     * I will be refenseing the extra low, low, mid, high, and extra high preset stats. 
     * if you are confused on this please visit the params.cs file to see the interface.
     * 
     * this randomizer and arrays are designed so when an assassin is made
     * so it cant have duplicate stats in attack and speed or defense and health.
     * assassins are supposed to have high speed and attakc but low defense and health.
     * the classes is purposefully designed when assigning stats that the assassin has 
     * mid to extra high stats in speed and attack but no duplicate stats. 
     * addtionally the assassin has mid to extra low stats in health and defense but no duplicates
     * 
     * this no duplicates is purposful so no assassin will have extra high attack and extra high speed.
     * the best case for an assassin is extra attack or speed and which ever gets the extra high the alternate would get high.
     * the worst case for an assassin would be mid attack or speed and which ever gets the mid the alternate would get high
     */

}

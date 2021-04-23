using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    /// <summary>
    /// the tank class is designed to create tanks using the CharCreator object
    /// </summary>
    class Tank : CharCreator
    {
        public override void defineChar(CharCreator temp)
        {
            int[] highStats = new int[] { 4, 3, 2 };
            int[] lowStats = new int[] { 0, 1, 2 };

            randomizeArray(highStats);
            randomizeArray(lowStats);

            this.Attack = attackStats[lowStats[0]];
            this.Speed = speedStats[lowStats[1]];
            this.Defense = defenseStats[highStats[0]];
            this.Health = healthStats[highStats[1]];
            this.Class = "Tank";
            base.defineChar(temp);
        }
    }

    /* Design Plan
     * I will be refenseing the extra low, low, mid, high, and extra high preset stats. 
     * if you are confused on this please visit the params.cs file to see the interface.
     * 
     * Tanks are designed to be the opposite to assassins in terms of stats.
     * I have realized that the high health stat is more valuable than the high speed stat.
     * consiquenly that is why the Mod stat was created in the damage calculator.
     * originally the mod stat was going to allow assassin to have a chance to crit however i decided to remove it.
     * it was removed because than the fighter and tank seemed a bit under equiped. 
     * additionally this is something for others to work from so i dont want to make the mod stat integral to the assassins.
     * a better design idea to buff assassins and go against tanks is to allow people with higher speed stats to attack twice in one turn.
     */
}

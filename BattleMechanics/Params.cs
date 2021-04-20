using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    /// <summary>
    /// This interface is designed to be applyed to CharCreator class
    /// It creates predefined varaibles so every character created this is the range for all stats
    /// 
    /// WARNNING
    /// altering these stats may break how the damage equation is done.
    /// The damage equation is designed so no class will ever do 0 damage 
    /// however if altered that may change or may lead to negative health dealt
    /// </summary>
    interface Params
    {
        //---Attack, Defense, Health, Speed Presets---
        protected const int ehAttack = 10; //Extra High
        protected const int hAttack = 9; //High
        protected const int mAttack = 8; //Mid
        protected const int lAttack = 7; //Low
        protected const int elAttack = 6; //Extra Low

        protected const int ehDefense = 5; //Extra High
        protected const int hDefense = 4; //High
        protected const int mDefense = 3; //Mid
        protected const int lDefense = 2; //Low
        protected const int elDefense = 1; //Extra Low

        protected const int ehHealth = 300; //Extra High
        protected const int hHealth = 250; //High
        protected const int mHealth = 200; //Mid
        protected const int lHealth = 150; //Low
        protected const int elHealth = 100; //Extra Low

        protected const int ehSpeed = 5; //Extra High
        protected const int hSpeed = 4; //High
        protected const int mSpeed = 3; //Mid
        protected const int lSpeed = 2; //Low
        protected const int elSpeed = 1; //Extra Low

    }
}

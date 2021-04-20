using System;
using System.Collections.Generic;
using System.Text;

namespace BattleMechanics
{
    /// <summary>
    /// The class is to allow other classes to create character objects
    /// the class uses the params interface which allows the creation of the stat arrays
    /// the arrays are for making character stat assigning easier on other classes.
    /// the over all purpose of the class is to make character creation both possible for other classes and easy
    /// </summary>
    class CharCreator : Params
    {

        //Array of stats for easier access
        protected int[] attackStats = new int[] { Params.elAttack, Params.lAttack, Params.mAttack, Params.hAttack, Params.ehAttack };
        protected int[] defenseStats = new int[] { Params.elDefense, Params.lDefense, Params.mDefense, Params.hDefense, Params.ehDefense };
        protected int[] healthStats = new int[] { Params.elHealth, Params.lHealth, Params.mHealth, Params.hHealth, Params.ehHealth };
        protected int[] speedStats = new int[] { Params.elSpeed, Params.lSpeed, Params.mSpeed, Params.hSpeed, Params.ehSpeed };

        //Character Stats
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; }
        public string ID { get; set; }
        public string Class { get; set; }

        /// <summary>
        /// This constructor sets up the variables that all characters will have
        /// additionally it generates a random ID.
        /// </summary>
        public CharCreator()
        {
            this.Attack = Attack;
            this.Defense = Defense;
            this.Health = Health;
            this.Speed = Speed;
            this.ID = generateID();
            this.Class = Class;
        }

        /// <summary>
        /// this generats a random ID based on the time.
        /// I have kept it low because IDs need to be retyped.
        /// 
        /// WARNNING
        /// if so many character are created that the code takes a full minute to run
        /// there may be a case where to characters have the same id.
        /// if a computer running this can create two characters within a microsecond 
        /// that will also lead to this ID system failing.
        /// </summary>
        /// <returns></returns>
        private string generateID()
        {
            string id = "";
            string temp = DateTime.Now.ToString("ss.ffffff");
            for (int i = 0; i < temp.Length; i++)
            {
                if (Char.IsDigit(temp[i]))
                {
                    id += temp[i];
                }
            }
            return id;
        }

        /// <summary>
        /// this method is designed to take in an array and randomize it.
        /// this is for the randomizing of the high and low varaibels when being assigned in the other classes
        /// </summary>
        /// <param name="arr1"></param>
        /// <returns></returns>
        public Array randomizeArray(Array arr1)
        {
            int[] arr2 = new int[arr1.Length];
            arr2 = (int[])arr1;
            Random rand = new Random();
            for (int i = 0; i < arr2.Length; i++)
            {
                int j = rand.Next(i, arr2.Length);
                int temp = arr2[i];
                arr2[i] = arr2[j];
                arr2[j] = temp;
            }
            return arr2;
        }
    }
}

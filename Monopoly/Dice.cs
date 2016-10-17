using System;


namespace Monopoly
{
    /// <summary>
    /// This is class for a Dice that generates random number 1-6 inclusive
    /// </summary>
    [Serializable]
    public class Dice
    {
        private static Random numGenerator = new Random();
        private int numberRolled;
        
        public int roll()
        {
            numberRolled = numGenerator.Next(1, 7);
            return numberRolled;
        }

        public int numberLastRolled()
        {
            return numberRolled;
        }
         
        public override string ToString()
        {
            return numberRolled.ToString();
        }
    }
}

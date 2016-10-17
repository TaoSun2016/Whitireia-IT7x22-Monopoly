﻿using System;
namespace Monopoly
{
    /// <summary>
    /// This is the class for the Banker which is a singleton and can trade money
    /// </summary>
    /// 
    [Serializable]
    public class Banker : Trader
    {
        //provide an static instance of this class to create singleton
        static Banker banker;

        public Banker()
        {
            this.setName("Banker");
            //suntao changed
            //this.setBalance(InitialValuesAccessor.getBankerStartingBalance());
            this.setBalance(Board.access().BankInitialBalance);

        }

        //method to access singleton
        public static Banker access()
        {
            if (banker == null)
                banker = new Banker();
            return banker;
        }
    }
}

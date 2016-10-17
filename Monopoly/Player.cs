using System;
using System.Collections;

namespace Monopoly
{

    /// <summary>
    /// Class for players playing monopoly
    /// </summary>
    [Serializable]
    public class Player : Trader
    {
        private int location;
        private int lastMove;

        public bool HasChanceFreeCard { get; set; }         //If the player has the free card
        public bool HasChestFreeCard { get; set; }          //If the player has the free card
        public bool IsInJail { get; set; }            //If the player is in jail
        public int DoubleCount { get; set; }          //The time of continuous doubles
        public int FailureRollDouble { get; set; }      //The failure time of rolling double
        //each player has two dice
        Dice dice1 = new Dice();
        Dice dice2 = new Dice();
        bool isInactive = false;

        //event for playerBankrupt
        public event EventHandler playerBankrupt;
        public event EventHandler playerPassGo;
        public event EventHandler playerLandOnChance;
        public event EventHandler playerGoJail;

        public Player()
        {
            this.sName = "Player";
            //suntao modified
            //this.dBalance = InitialValuesAccessor.getPlayerStartingBalance();
            this.dBalance = Board.access().PlayerInitialBalance;
            this.location = 0;
            HasChanceFreeCard = false;
            HasChestFreeCard = false;
            IsInJail = false;
            DoubleCount = 0;
            FailureRollDouble = 0;
        }

        public Player(string sName)
        {
            this.sName = sName;
            this.dBalance = Board.access().PlayerInitialBalance;
            //suntao modified
            //this.dBalance = InitialValuesAccessor.getPlayerStartingBalance();
            this.location = 0;
            HasChanceFreeCard = false;
            HasChestFreeCard = false;
            IsInJail = false;
            DoubleCount = 0;
            FailureRollDouble = 0;

        }


        public Player(string sName, decimal dBalance) : base(sName, dBalance)
        {
            this.location = 0;
            HasChanceFreeCard = false;
            HasChestFreeCard = false;
            IsInJail = false;
            DoubleCount = 0;
            FailureRollDouble = 0;

        }

        public void move()
        {

            //dice1.roll();
            //dice2.roll();
            //move distance is total of both throws
            int iMoveDistance = dice1.roll() + dice2.roll();
            Console.WriteLine($"{this.getName()}:    Rolling Dice:  Dice1:[{dice1}] Dice2:[{dice2}]");

            if (dice1.numberLastRolled()==dice2.numberLastRolled())
            {
                if (++this.DoubleCount>=3 && playerGoJail != null)
                {
                    Console.WriteLine($"{this.getName()}:    You have rolled double thrice and will be sent to Jail!");
                    this.playerGoJail(this,new EventArgs());
                    return;
                }
            }
            else
            {
                this.DoubleCount = 0;
            }

            //increase location
            this.setLocation(this.getLocation() + iMoveDistance);
            this.lastMove = iMoveDistance;
        }

        public int getLastMove()
        {
            return this.lastMove;
        }

        public string BriefDetailsToString()
        {
            return String.Format("You are on {0}.\tYou have ${1:N2}.", Board.access().getProperty(this.getLocation()).getName(), this.getBalance());
        }

        public override string ToString()
        {
            return this.getName();
        }

        public string FullDetailsToString()
        {
            return String.Format("Player:{0,-12}    Balance: ${1:N2}\nLocation:\n{2} (Square {3}) \n--------------------------------------------------------------------------------------------\nProperties Owned:\n{4}", this.getName(), this.getBalance(), Board.access().getProperty(this.getLocation()), this.getLocation(), this.PropertiesOwnedToString());
        }

        public string PropertiesOwnedToString()
        {
            string owned = "";
            //if none return none
            if (getPropertiesOwnedFromBoard().Count == 0)
                return "None";
            //for each property owned add to string owned
            for (int i = 0; i < getPropertiesOwnedFromBoard().Count; i++)
            {
                owned += getPropertiesOwnedFromBoard()[i].ToString() + "\n";
            }
            return owned;
        }

        public void setLocation(int location)
        {

            //if set location is greater than number of squares then move back to beginning
            if (location >= Board.access().getSquares())
            {
                location = (location - Board.access().getSquares());
                //raise the pass go event if subscribers
                if (playerPassGo != null)
                    this.playerPassGo(this, new EventArgs());
                //add 200 for passing go
                //suntao mode this function into Monopoly.playerPassGoHandler()
                //this.receive(200);
            }

            this.location = location;
            Property p = Board.access().getProperty(location);
            if (p.getName() == "Chance" || p.getName() == "Community Chest")
            {
                if (playerLandOnChance != null)
                {
                    this.playerLandOnChance(this, new EventArgs());

                }
            }
            if ("Go To Jail" == p.getName() && playerGoJail != null)
            {
                Console.WriteLine($@"{this.getName()}:  You landed on 'Go To Jail' and will be sent to Jail!!! ");
                this.playerGoJail(this,new EventArgs());
            }
        }

        public int getLocation()
        {
            return this.location;
        }

        public string diceRollingToString()
        {
            return String.Format("Rolling Dice:\tDice 1: {0}\tDice 2: {1}", dice1, dice2);
        }

        public ArrayList getPropertiesOwnedFromBoard()
        {
            ArrayList propertiesOwned = new ArrayList();
            //go through all the properties
            for (int i = 0; i < Board.access().getProperties().Count; i++)
            {
                //owned by this player
                if (Board.access().getProperty(i).getOwner() == this)
                {
                    //add to arraylist
                    propertiesOwned.Add(Board.access().getProperty(i));
                }
            }
            return propertiesOwned;
        }

        public override void checkBankrupt()
        {
            if (this.getBalance() <= 0)
            {
                //raise the player bankrupt event if there are subscribers
                if (playerBankrupt != null)
                    this.playerBankrupt(this, new EventArgs());

                //return all the properties to the bank
                Banker b = Banker.access();
                foreach (Property p in this.getPropertiesOwnedFromBoard())
                {
                    p.setOwner(b);
                }
                //set isInactive to true
                this.isInactive = true;


            }
        }

        public bool isNotActive()
        {
            return this.isInactive;
        }

    }
}

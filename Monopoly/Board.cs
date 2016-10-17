using System;
using System.Collections;

namespace Monopoly
{
    /// <summary>
    /// This is class for singleton Board that has properties and traders on it.
    /// </summary>

    [Serializable]
    public class Board
    {
        //provide an static instance of this class to create singleton
        static Board board;
        private ArrayList properties;
        private ArrayList players;
        private Queue chances;
        private Queue chests;
        int SQUARES = 0;

        public int CurrentPlayer { get; set; }
        public decimal BankInitialBalance { get; set; }
        public decimal PlayerInitialBalance { get; set; }

        //method to access singleton
        public static Board access()
        {
            if (board == null)
                board = new Board();
            return board;
        }

        //suntao change public into private
        private Board()
        {
            properties = new ArrayList();
            players = new ArrayList();
            chances = new Queue();
            chests = new Queue();
            CurrentPlayer = 0;
            SQUARES = 0;
            BankInitialBalance = 0.00m;
            PlayerInitialBalance = 0.00m;
        }


        public int getSquares()
        {
            return this.SQUARES;
        }

        //suntao add the method
        public void setSquares(int count)
        {
            this.SQUARES=count;
        }

        public void addPlayer(Player player)
        {

            foreach (Player p in players)
            {
                if (p.getName() == player.getName())
                {
                    Console.WriteLine($"Player with the name [{player.getName()}] has already existed!");
                    return;
                }
            }
            players.Add(player);

        }

        public void addProperty(Property property)
        {
            this.properties.Add(property);
        }

        public int getPlayerCount()
        {
            return players.Count;
        }

        public Player getPlayer(int playerIndex)
        {
            return (Player)players[playerIndex];
        }

        public Player getPlayer(string sName)
        {
            foreach (Player p in players)
            {
                if (p.getName() == sName)
                    return p;
            }

            // if no players with that name return null
            return null;
        }

        public Property getProperty(int propIndex)
        {
            return (Property)properties[propIndex];
        }

        public ArrayList getPlayers()
        {
            return this.players;
        }

        public ArrayList getProperties()
        {
            return this.properties;
        }

        public void clearPlayers()
        {
            this.players.Clear();
        }

        public void clearProperties()
        {
            this.properties.Clear();
            this.SQUARES = 0;
        }
        //suntao add 20161004
        public Queue getChances()
        {
            return this.chances;
        }

        //suntao add 20161004
        public Queue getChests()
        {
            return this.chests;
        }

        //suntao add 20161004
        public Card drawChance()
        {
            return (Card)this.chances.Dequeue();
        }

        //suntao add 20161004
        public void insertChance(Card card)
        {
           this.chances.Enqueue(card);
        }

        //suntao add 20161004
        public Card drawChest()
        {
            return (Card)this.chests.Dequeue();
        }

        //suntao add 20161004
        public void insertChest(Card card)
        {
            this.chests.Enqueue(card);
        }

        //suntao add 20160930
        public void load(Board b)
        {

            this.properties = b.getProperties();
            this.players = b.getPlayers();
            this.chances = b.getChances();
            this.chests = b.getChests();

            CurrentPlayer = b.CurrentPlayer;

            this.SQUARES = b.SQUARES;

            this.BankInitialBalance = b.BankInitialBalance;
            this.PlayerInitialBalance = b.PlayerInitialBalance;
        }
    }
}

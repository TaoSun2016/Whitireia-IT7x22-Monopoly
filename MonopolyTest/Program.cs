using System;
using Monopoly;
using NUnit.Framework;

namespace MonopolyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test cards
            /*
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadCards();
            m.loadProperties();

            Console.WriteLine("load success!!");

            Player p1 = new Player("Tom",1000);
            p1.playerBankrupt += Monopoly.Monopoly.playerBankruptHandler;
            p1.playerPassGo += Monopoly.Monopoly.playerPassGoHandler;
            p1.playerLandOnChance += Monopoly.Monopoly.playerLandOnChanceHandler;
            p1.playerGoJail += Monopoly.Monopoly.playerGoJailHandler;
            Board.access().addPlayer(p1);

            Player p2 = new Player("Jerry", 1000);
            p2.playerBankrupt += Monopoly.Monopoly.playerBankruptHandler;
            p2.playerPassGo += Monopoly.Monopoly.playerPassGoHandler;
            p2.playerLandOnChance += Monopoly.Monopoly.playerLandOnChanceHandler;
            p2.playerGoJail += Monopoly.Monopoly.playerGoJailHandler;
            Board.access().addPlayer(p2);

            Residential r = (Residential)Board.access().getProperty(1);
            r.setOwner(ref p1);
            r.addHouse();
            

            for (int i = 0;i<16;i++)
            {
                p1.setLocation(2);
                
                Console.WriteLine("balance=[{0}] location=[{1}] notactive=[{2}] injail=[{3}] haschancecard[{4}] haschestcard[{5}]", p1.getBalance(), Board.access().getProperty(p1.getLocation()).getName(),p1.isNotActive(),p1.IsInJail,p1.HasChanceFreeCard,p1.HasChestFreeCard);
                Console.WriteLine("----------------------------------------------");
            }
            Console.WriteLine("Number of cards[{0}]",Board.access().getChests().Count);
            Console.ReadLine();
            */

            //Test in Jail
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadCards();
            m.loadProperties();

            Console.WriteLine("load success!!");

            Player p1 = new Player("Tom", 1000);
            p1.playerBankrupt += Monopoly.Monopoly.playerBankruptHandler;
            p1.playerPassGo += Monopoly.Monopoly.playerPassGoHandler;
            p1.playerLandOnChance += Monopoly.Monopoly.playerLandOnChanceHandler;
            p1.playerGoJail += Monopoly.Monopoly.playerGoJailHandler;
            Board.access().addPlayer(p1);

            Player p2 = new Player("Jerry", 1000);
            p2.playerBankrupt += Monopoly.Monopoly.playerBankruptHandler;
            p2.playerPassGo += Monopoly.Monopoly.playerPassGoHandler;
            p2.playerLandOnChance += Monopoly.Monopoly.playerLandOnChanceHandler;
            p2.playerGoJail += Monopoly.Monopoly.playerGoJailHandler;
            Board.access().addPlayer(p2);

            //1. land on "Go to Jail"
            p1.setLocation(30);
            Console.WriteLine("Location=[{0}] isinJail=[{1}]",Board.access().getProperty(p1.getLocation()).getName(),p1.IsInJail);
            p1.setLocation(0);
            p1.IsInJail = false;
            //2. double thrice to go to Jail  hard code
            Monopoly.Monopoly.playerGoJailHandler(p1,new EventArgs() );
            Console.WriteLine("Balance=[{2}]Location=[{0}] isinJail=[{1}]", Board.access().getProperty(p1.getLocation()).getName(), p1.IsInJail,p1.getBalance());

            //2. Test the transactions when player in jail
            Board.access().getProperty(1).setOwner(ref p1);
            Board.access().getProperty(3).setOwner(ref p1);
            Board.access().getProperty(6).setOwner(ref p1);

            // player1 can collect rent
            p2.setLocation(1);
            Property propertyLandedOn = Board.access().getProperty(p2.getLocation());
            //landon property and output to console
            Console.WriteLine(">>>>>>>>>>" + propertyLandedOn.landOn(ref p2) + "<<<<<<<<<<");
            Console.WriteLine("Balance=[{2}]Location=[{0}] isinJail=[{1}]", Board.access().getProperty(p1.getLocation()).getName(), p1.IsInJail, p1.getBalance());
            Console.WriteLine("Balance=[{2}]Location=[{0}] isinJail=[{1}]", Board.access().getProperty(p2.getLocation()).getName(), p2.IsInJail, p2.getBalance());
            Console.ReadKey();
            //other functions' test

            p1.HasChanceFreeCard = true;
            m.playGame();
        }
    }
}

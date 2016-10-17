using System;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _MonopolyTest
    {
       
        [Test]
        public void TestInitializeGame()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.initializeGame();
        }

        [Test]
        public void TestLoadCards()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadCards();
            foreach (Card c in Board.access().getChances())
            {
                Console.WriteLine(c.ToString());
            }
            Assert.AreEqual(16, (int)Board.access().getChances().Count);


        }
        [Test]
        public void TestLoadProperties()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            Assert.AreEqual(40, Board.access().getProperties().Count);
        }
        [Test]
        public void TestEventLandOnChance()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            m.loadCards();
            Player player = new Player("SunTao");
            player.playerBankrupt += Monopoly.Monopoly.playerBankruptHandler;
            player.playerPassGo += Monopoly.Monopoly.playerPassGoHandler;
            player.playerLandOnChance += Monopoly.Monopoly.playerLandOnChanceHandler;
            //add player 
            Board.access().addPlayer(player);
           
            for (int i=0;i<16;i++)
            {
                Console.WriteLine($"{i+1}>>>=============================");

                player.setLocation(2);
                Property propertyLandedOn = Board.access().getProperty(player.getLocation());
                Console.WriteLine(propertyLandedOn.landOn(ref player));
                Console.WriteLine($"{player.getName()}'s balance={player.getBalance()}");
                Console.WriteLine($"{i + 1}=============================<<<");
            }
        }

        // need user's input
        [Test]
        public void TestBuyHouse()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            Player player = new Player("Tom",1000);

            m.buyHouse(player);

        }

        // need user's input
        [Test]
        public void TestDisplayMenuInJail()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            Player player = new Player("Tom", 1000);
            Board.access().addPlayer(player);

            m.displayMenuInJail(0);
        }

        // need user's input
        [Test]
        public void TestDisplayChoiceMenu()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            Player player = new Player("Tom", 1000);
            Board.access().addPlayer(player);

            m.displayPlayerChoiceMenu(player);
        }

        // need user's input
        [Test]
        public void TestDisplayPlayerChooser()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 1000);
            Player player3 = new Player("Dog", 1000);

            m.displayPlayerChooser(Board.access().getPlayers(),player1,"Hello");
        }

        // need user's input
        [Test]
        public void TestDisplayPropertyChooser()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 1000);
            Player player3 = new Player("Dog", 1000);

            m.displayPropertyChooser(Board.access().getProperties(),"Hello");
        }

        // need user's input
        [Test]
        public void TestGetinputYN()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            Player player = new Player("Tom", 1000);
            m.getInputYN(player,"Question");
        }

        // need user's input
        [Test]
        public void TestInputDecimal1()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();

            m.inputDecimal();

        }

        // need user's input
        [Test]
        public void TestInputDecimal2()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();

            m.inputDecimal("Decimal");
        }

        // need user's input
        [Test]
        public void TestLoadGame()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();

            m.loadGame();
        }

        // need user's input
       [Test]
        public void TestMakePlay()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            m.loadCards();
             Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 1000);
            Board.access().addPlayer(player1);
            Board.access().addPlayer(player2);
            m.makePlay(0);

        }



        // need user's input
        [Test]
        public void TestMortage()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            m.loadCards();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 1000);
            m.mortgageProperty(player1);
            Board.access().getProperty(1).setOwner(ref player1);
            m.mortgageProperty(player1);

        }

        [Test]
        public void TestPayForLeave()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 10);
            player1.IsInJail = true;
            player2.IsInJail = true;

            m.payForLeave(player1);
            Assert.AreEqual(false,player1.IsInJail);
            m.payForLeave(player2);
            Assert.AreEqual(true, player1.IsInJail);
        }

        //need user's input
        [Test]
        public void TestPlayGame()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 10);
            m.loadProperties();
            m.loadCards();
            Board.access().addPlayer(player1);
            Board.access().addPlayer(player2);
            m.playGame();
        }

        //there is exit
        [Test]
        public void TestPrintWinner()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 10);
            m.loadProperties();
            m.loadCards();
            Board.access().addPlayer(player1);
            Board.access().addPlayer(player2);          
        }

        //need user's input
        [Test]
        public void TestPurchaseProperty()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 10);
            m.loadProperties();
            m.loadCards();
            Board.access().addPlayer(player1);
            Board.access().addPlayer(player2);

            m.purchaseProperty(player1);

            player1.setLocation(1);
            m.purchaseProperty(player1);
        }

        //there is exit
        [Test]
        public void TestQuitGame()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            //m.quitGame();
        }

        [Test]
        public void TestRollDouble()
        {
           
            bool trueResult=false;
            Player player = new Player("Tom", 1000);
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            for (int k =0;k<1000;k++)
            {
                trueResult = m.rollDouble(player);
                if (trueResult) break;
            }
            Assert.IsTrue(trueResult);
        }

        [Test]
        public void TestSaveGame()
        {

            
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 1000);

            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            m.loadCards();
            Board.access().addPlayer(player1);
            Board.access().addPlayer(player2);

            m.saveGame();
        }

        //need user's input
        [Test]
        public void TestSellHouse()
        {

            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            m.loadCards();
            Player player1 = new Player("Tom", 1000);

            Board.access().addPlayer(player1);
            m.sellHouse(player1);
        }

        //need user's input
        [Test]
        public void TestSetupGame()
        {

            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.setUpGame();
        }

        //need user's input
        [Test]
        public void TestTradeProperty()
        {

            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            m.loadCards();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 1000);

            Board.access().addPlayer(player1);
            Board.access().addPlayer(player2);

            m.tradeProperty(player1);
        }

        //need user's input
        [Test]
        public void TestUnmortgage()
        {

            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            m.loadCards();
            Player player1 = new Player("Tom", 1000);
            Player player2 = new Player("Jerry", 1000);

            Board.access().addPlayer(player1);
            Board.access().addPlayer(player2);

            m.unmortgageProperty(player1);
        }

        [Test]
        public void TestUseFreeCard()
        {

            Monopoly.Monopoly m = new Monopoly.Monopoly();
            Player player = new Player("Tom", 1000);
            player.IsInJail = true;

            m.useFreeCard(player);
            Assert.IsTrue(player.IsInJail);

            player.HasChanceFreeCard = true;
            m.useFreeCard(player);
            Assert.IsFalse(player.IsInJail);

            player.IsInJail = true;
            player.HasChestFreeCard = true;
            m.useFreeCard(player);
            Assert.IsFalse(player.IsInJail);
        }
   
    }
}

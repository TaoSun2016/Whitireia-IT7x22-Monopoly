using System;
using System.Collections;
using NUnit.Framework;
using Monopoly;


namespace MonopolyTest
{
    class _PlayerTest
    {
        [Test]
        public void TestMove()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadData();
            Player player = Board.access().getPlayer(0);
            player.move();
            Assert.Greater(player.getLastMove(), 0);
            Assert.Greater(player.getLocation(), 0);
        }
        [Test]
        public void TestString()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadData();
            Player player = Board.access().getPlayer(0);

            string name = player.getName();
            Player p = new Player("NoProperty");




            Assert.IsNotEmpty(player.BriefDetailsToString());
            Assert.IsNotEmpty(player.FullDetailsToString());
            Assert.AreEqual(name, player.ToString());
            Assert.IsNotEmpty(player.diceRollingToString());

            Assert.IsNotEmpty(player.PropertiesOwnedToString());
            Board.access().getProperty(1).setOwner(ref player);
            Assert.IsNotEmpty(player.PropertiesOwnedToString());
            Assert.AreEqual("None",p.PropertiesOwnedToString());


        }
        [Test]
        public void TestActive()
        {
            Player player = new Player("Tom");
            Assert.IsFalse(player.isNotActive());
        }
        [Test]
        public void TestEvent()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            m.loadCards();

            Player player = new Player("Tom",1000);
            player.playerBankrupt += Monopoly.Monopoly.playerBankruptHandler;
            player.playerPassGo += Monopoly.Monopoly.playerPassGoHandler;
            player.playerLandOnChance += Monopoly.Monopoly.playerLandOnChanceHandler;
            player.playerGoJail += Monopoly.Monopoly.playerGoJailHandler;
            Board.access().addPlayer(player);
            ((Residential)Board.access().getProperty(1)).setOwner(ref player);

            player.pay(2000);

            Assert.AreEqual(true,player.isNotActive());

            Player p = new Player("Jerry", 1000);
            p.playerBankrupt += Monopoly.Monopoly.playerBankruptHandler;
            p.playerPassGo += Monopoly.Monopoly.playerPassGoHandler;
            p.playerLandOnChance += Monopoly.Monopoly.playerLandOnChanceHandler;
            p.playerGoJail += Monopoly.Monopoly.playerGoJailHandler;

            Board.access().clearPlayers();
            Board.access().addPlayer(p);

            p.setLocation(30);
            Assert.AreEqual(true, p.IsInJail);


            Player p1 = new Player("Dog", 1000);
            p1.playerBankrupt += Monopoly.Monopoly.playerBankruptHandler;
            p1.playerPassGo += Monopoly.Monopoly.playerPassGoHandler;
            p1.playerLandOnChance += Monopoly.Monopoly.playerLandOnChanceHandler;
            p1.playerGoJail += Monopoly.Monopoly.playerGoJailHandler;
            Board.access().clearPlayers();
            Board.access().addPlayer(p1);


            p1.setLocation(40);
            Assert.AreEqual(0,p1.getLocation());

            
            p1.setLocation(2);


        }
    }
}

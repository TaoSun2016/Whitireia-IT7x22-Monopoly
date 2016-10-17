using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _BoardTest
    {
        [Test]
        public void TestConstructor()
        {
            Assert.AreSame(Board.access(),Board.access());
        }

        [Test]
        public void TestManapulatePlayers()
        {
            Console.WriteLine("Number of palyers:"+Board.access().getPlayerCount());
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadData();
            int i = Board.access().getPlayers().Count;

            Board.access().addPlayer(new Player("AAA"));
            Board.access().addPlayer(new Player("BBB"));
            Assert.AreEqual(i+2, Board.access().getPlayerCount());     
            Assert.IsNotEmpty(Board.access().getPlayer(2).getName());  
            Assert.AreEqual("AAA", Board.access().getPlayer("AAA").getName()); 
            Assert.IsNull(Board.access().getPlayer("NN"));
            i = Board.access().getPlayers().Count;
            Board.access().addPlayer(new Player("AAA"));
            Assert.AreEqual(i, Board.access().getPlayers().Count);
        }
        [Test]
        public void TestManapulateProperties()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadData();
            Board.access().addProperty(new Property());
            Console.WriteLine(Board.access().getProperties().Count+"    "+ Board.access().getProperty(0).getName());
            Assert.AreEqual("Go",Board.access().getProperty(0).getName());
            int i =Board.access().getProperties().Count;
            Assert.Less(1, i);
            Board.access().clearProperties();
            Assert.AreEqual(0,Board.access().getSquares());
        }
        [Test]
        public void TestDrawChance()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadCards();
            Card card = Board.access().drawChance();
            Console.WriteLine(card.Description);
            Assert.IsNotEmpty(card.Description);
        }
        [Test]
        public void TestDrawChest()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadCards();
            Card card = Board.access().drawChest();
            Console.WriteLine(card.Description);
            Assert.IsNotEmpty(card.Description);
        }

        [Test]
        public void TestLoad()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream file = new FileStream("monopoly.sav", FileMode.Open))
            {
                Board.access().load((formatter.Deserialize(file) as Board));

            }
            Assert.Greater(Board.access().getChances().Count, 1);
            Player player = Board.access().getPlayer(0);
            Assert.IsNotEmpty(player.getName());
            player = Board.access().getPlayer("");

            Assert.IsNull(player);
            player = Board.access().getPlayer("Tom");
            Assert.IsNotNull(player);


        }

    }
}

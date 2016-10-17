using Monopoly;
using NUnit.Framework;


namespace MonopolyTest
{
    class _FreeCardTest
    {
        [Test]
        public void TestExecuation()
        {
            FreeCard card1 = new FreeCard("Chest","FREE","free from jail");
            FreeCard card2 = new FreeCard("Chance", "FREE", "free from jail");

            Player p1 = new Player("Tom",1000m);
            Player p2 = new Player("Jerry",1000m);
            card1.ExecuteInstruction(p1);
            Assert.AreEqual(true,p1.HasChestFreeCard);
            card2.ExecuteInstruction(p1);
            Assert.AreEqual(true, p1.HasChanceFreeCard);
        }
        [Test]
        public void TestTradeFreeCard()
        {
            Player p1 = new Player("Tom", 1000m);
            Player p2 = new Player("Jerry", 1000m);

            FreeCard card1 = new FreeCard("Chest", "FREE", "free from jail");
            FreeCard card2 = new FreeCard("Chance", "FREE", "free from jail");
            Assert.AreEqual(false, card1.TradeFreeCard(p1, p2, 10m));
            card1.ExecuteInstruction(p1);
            card2.ExecuteInstruction(p1);
            Assert.AreEqual(false, card1.TradeFreeCard(p1, p2, 10000m));
            Assert.AreEqual(true, card1.TradeFreeCard(p1, p2, 10m));
            Assert.AreEqual(true, card1.TradeFreeCard(p1, p2, 10m));



        }
    }
}

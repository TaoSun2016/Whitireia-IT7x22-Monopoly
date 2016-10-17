using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _MovingCardTest
    {
        [Test]
        public void TestMovingCared()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();

            MovingCard card = new MovingCard("Chance","MOVE","failed movement",null);
            Player player = new Player("Tom");
            card.ExecuteInstruction(player);
            Assert.AreEqual(0, player.getLocation());

            m.loadProperties();
            card.Destination = "KKKK";
            card.ExecuteInstruction(player);
            Assert.AreEqual(0, player.getLocation());

            card.Steps = 0;
            card.Destination = "Ohakune Carrot";

            player.setLocation(6);
            card.ExecuteInstruction(player);
            Assert.AreEqual(1, player.getLocation());

            card.Steps = 2;
            card.ExecuteInstruction(player);
            Assert.AreEqual(3, player.getLocation());


        }
    }
}

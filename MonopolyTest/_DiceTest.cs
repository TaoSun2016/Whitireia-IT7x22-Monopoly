using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _DiceTest
    {
        [Test]
        public void TestRoll()
        {
            int i;
            Dice dice = new Dice();
            i = dice.roll();
            if (i>=1 && i<=6)
                Assert.Pass();
        }
        [Test]
        public void TestnumberLastRolled()
        {
            int i;
            Dice dice = new Dice();
            i = dice.roll();
            Assert.AreEqual(i,dice.numberLastRolled());
        }
        [Test]
        public void TestToString()
        {
            int i;
            Dice dice = new Dice();
            i = dice.roll();
            Assert.AreEqual(i.ToString(),dice.ToString());
        }
    }
}

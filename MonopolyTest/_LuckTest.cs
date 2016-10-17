using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _LuckTest
    {
        [Test]
        public void TestConstructor()
        {
            Luck luck = new Luck();
            Assert.AreEqual("Luck Property:\tOwned by: Banker", luck.ToString());
        }
        [Test]
        public void TestLandon()
        {
            Luck luck = new Luck();
            Player player = new Player();
            luck.landOn(ref player);
            Assert.AreEqual(1550,player.getBalance());

            Luck luck1 = new Luck("Bad",false,50);
            luck1.landOn(ref player);
            Assert.AreEqual(1500, player.getBalance());
        }
    }
}

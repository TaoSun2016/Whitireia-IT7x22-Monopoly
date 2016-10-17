using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _LuckFactoryTest
    {
        [Test]
        public void TestCrate()
        {
            LuckFactory luckFactory = new LuckFactory();
            Luck luck;
            luck = luckFactory.create("Luck",true,50);
            Assert.AreEqual("Luck",luck.getName());
        }
    }
}

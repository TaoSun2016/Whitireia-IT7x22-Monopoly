using Monopoly;
using NUnit.Framework;

namespace MonopolyTest
{
    class _BankerTest
    {
        [Test]
        public void TestDefaultConstructor()
        {
            Banker.access();
            Assert.AreEqual("Banker",Banker.access().getName());
            Assert.LessOrEqual(0.00m, Banker.access().getBalance());
        }

        [Test]
        public void TestAccess()
        {
            Assert.AreSame(Banker.access(), Banker.access());
        }
    }
}

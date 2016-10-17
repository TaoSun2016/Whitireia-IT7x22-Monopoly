using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _InitialValueTest
    {
        [Test]
        public void TestGetBankerStartBalance()
        {
            Assert.AreEqual(10000, InitialValuesAccessor.getBankerStartingBalance());
        }
        [Test]
        public void TestGetPlayerStartBalance()
        {
            Assert.AreEqual(1500, InitialValuesAccessor.getPlayerStartingBalance());
        }
    }
}

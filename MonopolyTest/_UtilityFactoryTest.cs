using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _UtilityFactoryTest
    {
        [Test]
        public  void TestCreate()
        {
            UtilityFactory ut = new UtilityFactory();
            Utility u;
            u = ut.create("Utility");
            Assert.AreEqual("Utility", u.getName());
        }
    }
}

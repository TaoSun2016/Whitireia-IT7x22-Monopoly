using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _ResidentialFactoryTest
    {
        [Test]
        public void TestCreate()
        {
            ResidentialFactory rf = new ResidentialFactory();
            Residential r = rf.create("Hotel", 1000, 10, 15);
            Assert.AreEqual("Hotel", r.getName());
        }
    }
}

using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _ResidentialTest
    {
        [Test]
        public void TestConstructor()
        {
            Residential r = new Residential();
            Assert.Greater( r.ToString().Length,0);
        }
        [Test]
        public void TestGet()
        {
            Residential r = new Residential();
            Assert.AreEqual(50, r.getHouseCost());
            Assert.AreEqual(0, r.getHouseCount());
            Assert.AreEqual(50, r.getRent());
            Assert.AreEqual(200, r.getPrice());
            Assert.AreEqual(4, Residential.getMaxHouses());
        }
        [Test]
        public void TestAddAndReducehouse()
        {
            Residential r = new Residential();
            Player p = new Player("Tom",1000);
            r.setOwner(ref p);
            r.addHouse();
            Assert.AreEqual(1, r.getHouseCount());
            r.reduceHouse();
            Assert.AreEqual(0, r.getHouseCount());

        }

    }
}

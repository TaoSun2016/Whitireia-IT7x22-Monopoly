using NUnit.Framework;
using Monopoly;
namespace MonopolyTest
{
    class _UtilityTest
    {
        [Test]
        public void TestConstructor()
        {
            Utility u = new Utility();
            Assert.AreEqual("Utility:\tOwned by: Banker", u.ToString());
        }
        [Test]
        public void TestPayRent()
        {
            Utility u = new Utility();
            Player p = new Player();
            p.move();
            int i=p.getLastMove();

            decimal old_bal1 = p.getBalance();
            decimal old_bal2 = Banker.access().getBalance();
            u.payRent(ref p);


            Assert.AreEqual(old_bal1-i*6,p.getBalance());
            Assert.AreEqual(old_bal2+i*6, Banker.access().getBalance());
        }
        [Test]
        public void TestLandOn()
        {
            Utility u = new Utility();
            Player p = new Player("Tom");
            Player q = new Player("Jerry");
            Assert.AreEqual("Tom landed on Utility. ", u.landOn(ref p));
            q.move();
            int i = q.getLastMove();
            u.setOwner(ref p);
            u.landOn(ref q);
            Assert.AreEqual(1500-i*6,q.getBalance());
            Assert.AreEqual(1500 + i * 6, p.getBalance());

        }
    }
}

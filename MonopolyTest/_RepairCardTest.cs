using Monopoly;
using NUnit.Framework;

namespace MonopolyTest
{
    class _RepairCardTest
    {
        [Test]
        public void TestRepair()
        {
            RepairCard c = new RepairCard("Chance","REPAIR","repair house",100,100);
            Player p = new Player("Tom",1000);
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.loadProperties();
            Board.access().getProperty(1).setOwner(ref p);
            ((Residential)Board.access().getProperty(1)).addHouse();
            c.ExecuteInstruction(p);
            Assert.Less(p.getBalance(),1000);

        }
    }
}

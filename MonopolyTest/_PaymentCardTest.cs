using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _PaymentCardTest
    {
        [Test]
        public void TestPaymentCard()
        {
            PaymentCard pc = new PaymentCard("Chance","PAYALL","pay money to all",10);
            PaymentCard pc1 = new PaymentCard("Chance", "COLLECT", "receive all", 10);
            PaymentCard pc2 = new PaymentCard("Chance", "PAY", "pay", 10);
            PaymentCard pc3 = new PaymentCard("Chance", "RCV", "receive", 10);


            System.Console.WriteLine(pc);
            Player p1 = new Player("Tom-paymentcard",1000);
            Player p2 = new Player("Jerry-paymentcard", 1000);
            Player p3 = new Player("Dog-paymentcard", 1000);

            Board.access().clearPlayers();
            Board.access().addPlayer(p1);
            Board.access().addPlayer(p2);
            Board.access().addPlayer(p3);
                pc.ExecuteInstruction(p1);
            Assert.AreEqual(980,Board.access().getPlayer("Tom-paymentcard").getBalance());
            Assert.AreEqual(1010, Board.access().getPlayer("Jerry-paymentcard").getBalance());
            Assert.AreEqual(1010, Board.access().getPlayer("Dog-paymentcard").getBalance());
            pc1.ExecuteInstruction(p1);
            Assert.AreEqual(1000, Board.access().getPlayer("Tom-paymentcard").getBalance());
            Assert.AreEqual(1000, Board.access().getPlayer("Jerry-paymentcard").getBalance());
            Assert.AreEqual(1000, Board.access().getPlayer("Dog-paymentcard").getBalance());
            pc2.ExecuteInstruction(p1);
            Assert.AreEqual(990, Board.access().getPlayer("Tom-paymentcard").getBalance());
            pc3.ExecuteInstruction(p1);
            Assert.AreEqual(1000, Board.access().getPlayer("Tom-paymentcard").getBalance());




            Board.access().getPlayer("Tom-paymentcard").setBalance(10);
            pc.ExecuteInstruction(p1);
            System.Console.WriteLine(p1.isNotActive());
            Assert.AreEqual(true,p1.isNotActive());

            p1.setBalance(1000);
            PaymentCard pcc = new PaymentCard("Chance", "dddd", "pay money to all", 10);
            pcc.ExecuteInstruction(p1);
            System.Console.WriteLine(p1.getBalance());
            Assert.AreEqual(1000, p1.getBalance());



        }
    }
}

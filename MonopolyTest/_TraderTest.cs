using System;
using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _TraderTest
    {
        [Test]
        public void TestDefaultConstructor()
        {
            Monopoly.Trader trader = new Monopoly.Trader();
            Assert.IsNotNull(trader);
            Assert.AreEqual("Name:  \nBalance: 0", trader.ToString());
        }
        [Test]
        public void TestConstructorWithParameter()
        {
            Monopoly.Trader trader = new Monopoly.Trader("Tom",1000000.00M);
            Assert.AreEqual("Tom", trader.getName());
            Assert.AreEqual(1000000.00, trader.getBalance());
        }
        [Test]
        public void TestSetFunctions()
        {
            Monopoly.Trader trader = new Monopoly.Trader();
            trader.setBalance(1000000.00M);
            trader.setName("Tom");
            Assert.AreEqual("Tom", trader.getName());
            Assert.AreEqual(1000000.00, trader.getBalance());
        }
        [Test]
        public  void TestCheckBankrupt()
        {
            decimal balance = -10.00m;
            Monopoly.Trader trader = new Monopoly.Trader();
            trader.setBalance(balance);

            try
            {
                trader.checkBankrupt();
            }
            catch (ApplicationException e)
            {
                Assert.IsNotNull(e);
            }
        }
        [Test]
        public void TestPayAndReceive()
        {
            decimal payAmount = 5.00m;
            decimal receiveAmount = 10.00m;

            Monopoly.Trader trader = new Monopoly.Trader();
            trader.receive(receiveAmount);
            Assert.AreEqual(10.00, trader.getBalance());
            trader.pay(payAmount);
            Assert.AreEqual(5.00, trader.getBalance());
        }
        [Test]
        public void TestObtainProperty()
        {
            Trader trader = new Trader();
            Property property = new Property();
            Assert.AreEqual(0,trader.getPropertiesOwned().Count);
            trader.obtainProperty(ref property);
            Assert.AreEqual(1, trader.getPropertiesOwned().Count);
        }
        [Test]
        public void TesttradeProperty()
        {
            Player player = new Player("Tom");
            Player player1 = new Player("Jerry");

            TradableProperty property = new TradableProperty();
            property.setOwner(ref player);

            Assert.AreEqual("Tom",property.getOwner().getName());
            Assert.AreEqual(1500,property.getOwner().getBalance());
            Assert.AreEqual("Jerry",player1.getName());
            Assert.AreEqual(1500, player1.getBalance());

            player.tradeProperty(ref property,ref player1,property.getPrice());

            Assert.AreEqual("Jerry", property.getOwner().getName());
            Assert.AreEqual(1300, property.getOwner().getBalance());
            Assert.AreEqual("Tom", player.getName());
            Assert.AreEqual(1700, player.getBalance());
        }
    }
}

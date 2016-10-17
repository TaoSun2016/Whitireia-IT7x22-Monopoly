using System;
using Monopoly;
using NUnit.Framework;

namespace MonopolyTest
{
    class _TradablePropertyTest
    {
        [Test]
        public void TestDefaultConstructor()
        {
            TradableProperty tradableProperty = new TradableProperty();
            Assert.AreEqual("Property",tradableProperty.getName());
            Assert.AreEqual(200m,tradableProperty.getPrice());
            Assert.AreEqual(50, tradableProperty.getRent());
            Assert.AreEqual("Property:\tOwned by: Banker",tradableProperty.ToString());
            Assert.IsTrue(tradableProperty.availableForPurchase());

        }
        [Test]
        public void TestSetOwnerAndAvailable()
        {
            TradableProperty tradableProperty = new TradableProperty();
            Banker banker=Banker.access();
            tradableProperty.setOwner( banker);
            Assert.IsTrue(tradableProperty.availableForPurchase());
            Player player = new Player();
            tradableProperty.setOwner(ref player);
            Assert.IsFalse(tradableProperty.availableForPurchase());
        }
        [Test]
        public void TestPayrent()
        {
            TradableProperty tradableProperty = new TradableProperty();
            Player player = new Player("Tom");
            Player player2 = new Player("Jerry");
            tradableProperty.setOwner(ref player2);
            tradableProperty.payRent(ref player);
            Assert.AreEqual(1450, player.getBalance());
            Assert.AreEqual(1550, tradableProperty.getOwner().getBalance());
        }

        [Test]
        public void TestLandon()
        {
            TradableProperty tradableProperty = new TradableProperty();
            Player player = new Player("Tom");
            
            Assert.AreEqual("Tom landed on Property. ", tradableProperty.landOn(ref player));
            tradableProperty.setOwner(ref player);
            Player player2 = new Player("Jerry", 10000.00m);
            Assert.AreEqual("Jerry landed on Property. Rent has been paid for Property of $50 to Tom.", tradableProperty.landOn(ref player2));
        }
        [Test]
        public void TestPurchase()
        {
            TradableProperty tradableProperty = new TradableProperty();
            Player player = new Player("Tom");
            tradableProperty.purchase(ref player);
            Assert.AreEqual(player.getBalance(), 1300);
            Assert.AreEqual(tradableProperty.getOwner().getName(),"Tom");
            Player player2 = new Player("Jerry");
            try
            {
                tradableProperty.purchase(ref player2);
            }catch(ApplicationException e)
            {
                Assert.AreEqual("System.ApplicationException", e.ToString().Substring(0,27));
            }
        }
        [Test]
        public void TestProperty()
        {
            Trader trader = new Trader();
            Property property = new Property("Tome",ref trader);
            Assert.IsFalse(property.availableForPurchase());
        }
        [Test]
        public void TestPropertyFactory()
        {
            PropertyFactory factory = new PropertyFactory();
            Property p;
            p = factory.create("Tom");
            Assert.AreEqual("Tom", p.getName());
        }
        [Test]
        public void TestMortgage()
        {
            TradableProperty p = new TradableProperty();
            Player player = new Player("Tom",1000m);

            Assert.AreEqual(100m,p.getMortgageValue());
            p.mortgage(player);

            Assert.AreEqual(true,p.IsMortgaged);
            Assert.AreEqual(player.getBalance(),1100);

            player.setBalance(100m);
            Assert.AreEqual(false,p.unmortgage(player));
            player.setBalance(1110m);
            Assert.AreEqual(true, p.unmortgage(player));
            Assert.AreEqual(player.getBalance(), 1000);






        }
    }
}

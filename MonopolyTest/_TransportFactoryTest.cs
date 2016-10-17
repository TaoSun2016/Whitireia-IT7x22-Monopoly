using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _TransportFactoryTest
    {
        [Test]
        public void TestCreate()
        {
            TransportFactory tf = new TransportFactory();
            Transport t;
            t = tf.create("Bus Stop");
            Assert.AreEqual("Bus Stop", t.getName());          
        }
    }
}

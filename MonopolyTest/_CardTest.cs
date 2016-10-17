using NUnit.Framework;
using Monopoly;

namespace MonopolyTest
{
    class _CardTest
    {
        [Test]
        public void TestCard()
        {
            Card card = new Card("Chance","Move","move to some place");
            card.ExecuteInstruction(new Player());
        }
    }
}

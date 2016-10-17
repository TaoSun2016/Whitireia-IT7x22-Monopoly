using NUnit.Framework;
using Monopoly;
namespace MonopolyTest
{
    class _GameTest
    {
        [Test]
        public void TestPlayOneGame()
        {
            Monopoly.Monopoly m = new Monopoly.Monopoly();
            m.playOneGame(1);
        }
    }
}

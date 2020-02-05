using NUnit.Framework;

namespace FootballGoals.UnitTest
{
    public class MatchTests
    {
        [Test]
        public void TestMatchNoGoals()
        {
            var match = new Match(2, 'U');
            var textLine = match.GetTextLine();
            Assert.AreEqual("Kamp 02 0-0 U Riktig", textLine);
            Assert.IsTrue(match.IsBetCorrect);
        }

        [Test]
        public void TestMatchNo()
        {
            var match = new Match(3, 'U');
            var textLine = match.GetTextLine();
            Assert.AreEqual("Kamp 03 0-0 U Riktig", textLine);
        }

        [Test]
        public void TestMatchNoBiggerThan10()
        {
            var match = new Match(11, 'U');
            var textLine = match.GetTextLine();
            Assert.AreEqual("Kamp 11 0-0 U Riktig", textLine);
        }
    }
}
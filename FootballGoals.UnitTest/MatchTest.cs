using NUnit.Framework;

namespace FootballGoals.UnitTest
{
    public class MatchTest
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

        [Test]
        public void TestMatchWrongBet()
        {
            var match = new Match(11, 'H');
            var textLine = match.GetTextLine();
            Assert.AreEqual("Kamp 11 0-0 U Feil (Du tippet H)", textLine);
            Assert.IsFalse(match.IsBetCorrect);
        }

        [Test]
        public void TestMatchOneGoalHome()
        {
            var match = new Match(2, 'H');
            var isSuccess = match.AddGoal('H');
            var textLine = match.GetTextLine();
            Assert.AreEqual("Kamp 02 1-0 H Riktig", textLine);
            Assert.IsTrue(isSuccess);
        }

        [Test]
        public void TestMatchOneGoalHome2()
        {
            var match = new Match(2, 'H');
            var isSuccess = match.AddGoal('h');
            var textLine = match.GetTextLine();
            Assert.AreEqual("Kamp 02 1-0 H Riktig", textLine);
            Assert.IsTrue(isSuccess);
        }

        [Test]
        public void TestMatchOneGoalAway()
        {
            var match = new Match(2, 'B');
            var isSuccess = match.AddGoal('B');
            var textLine = match.GetTextLine();
            Assert.AreEqual("Kamp 02 0-1 B Riktig", textLine);
            Assert.IsTrue(isSuccess);
        }

        [Test]
        public void TestMatchInvalidGoal()
        {
            var match = new Match(2, 'H');
            var isSuccess = match.AddGoal('X');
            Assert.IsFalse(isSuccess);
        }
    }
}
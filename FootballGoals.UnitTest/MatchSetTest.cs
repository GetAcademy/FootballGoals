using System;
using System.Collections.Generic;
using System.Text;
using FootballGoals.UI;
using NUnit.Framework;

namespace FootballGoals.UnitTest
{
    public class MatchSetTest
    {
        [Test]
        public void TestNoGoals()
        {
            var matchSet = new MatchSet("UUUUUUUUUUUU");
            var text = matchSet.GetText();
            var lines = text.Split('\n');
            for (var i = 0; i < 12; i++)
            {
                Assert.AreEqual($"Kamp {(i + 1):D2} 0-0 U Riktig", lines[i]);
            }
        }

        [Test]
        public void TestOneHomeGoal()
        {
            var matchSet = new MatchSet("UUUUUUUUUUUU");
            matchSet.AddGoal("h2");
            var text = matchSet.GetText();
            var lines = text.Split('\n');
            Assert.AreEqual("Kamp 02 1-0 H Feil (Du tippet U)", lines[1]);
        }

        [Test]
        public void TestInvalidGoal()
        {
            var matchSet = new MatchSet("UUUUUUUUUUUU");
            var isSuccess = matchSet.AddGoal("");
            Assert.IsFalse(isSuccess);
        }

        [Test]
        public void TestInvalidBet()
        {
            try
            {
                var matchSet = new MatchSet("sjkdg");
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
                Assert.Pass();
            }
        }
    }
}

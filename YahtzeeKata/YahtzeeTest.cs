using NUnit.Framework;

namespace YahtzeeKata
{
    [TestFixture]
    public class YathzeeTest
    {
        [Test]
        public void Score_chance()
        {
            Assert.AreEqual(15, new YahtzeeScorer(2, 3, 4, 5, 1).Chance());
            Assert.AreEqual(16, new YahtzeeScorer(3, 3, 4, 5, 1).Chance());
        }

        [Test]
        public void Score_ones()
        {
            Assert.AreEqual(1, new YahtzeeScorer(1, 2, 3, 4, 5).Ones());
            Assert.AreEqual(2, new YahtzeeScorer(1, 2, 1, 4, 5).Ones());
            Assert.AreEqual(0, new YahtzeeScorer(6, 2, 2, 4, 5).Ones());
            Assert.AreEqual(4, new YahtzeeScorer(1, 2, 1, 1, 1).Ones());
        }

        [Test]
        public void Score_twos()
        {
            Assert.AreEqual(4, new YahtzeeScorer(1, 2, 3, 2, 6).Twos());
            Assert.AreEqual(10, new YahtzeeScorer(2, 2, 2, 2, 2).Twos());
        }

        [Test]
        public void Score_threes()
        {
            Assert.AreEqual(6, new YahtzeeScorer(1, 2, 3, 2, 3).Threes());
            Assert.AreEqual(12, new YahtzeeScorer(2, 3, 3, 3, 3).Threes());
        }

        [Test]
        public void Score_fours()
        {
            Assert.AreEqual(12, new YahtzeeScorer(4, 4, 4, 5, 5).Fours());
            Assert.AreEqual(8, new YahtzeeScorer(4, 4, 5, 5, 5).Fours());
            Assert.AreEqual(4, new YahtzeeScorer(4, 5, 5, 5, 5).Fours());
        }

        [Test]
        public void Score_fives()
        {
            Assert.AreEqual(10, new YahtzeeScorer(4, 4, 4, 5, 5).Fives());
            Assert.AreEqual(15, new YahtzeeScorer(4, 4, 5, 5, 5).Fives());
            Assert.AreEqual(20, new YahtzeeScorer(4, 5, 5, 5, 5).Fives());
        }

        [Test]
        public void Score_sixes()
        {
            Assert.AreEqual(0, new YahtzeeScorer(4, 4, 4, 5, 5).Sixes());
            Assert.AreEqual(6, new YahtzeeScorer(4, 4, 6, 5, 5).Sixes());
            Assert.AreEqual(18, new YahtzeeScorer(6, 5, 6, 6, 5).Sixes());
        }

        [Test]
        public void Score_yathzee()
        {
            Assert.AreEqual(50, new YahtzeeScorer(4, 4, 4, 4, 4).Yahtzee());
            Assert.AreEqual(50, new YahtzeeScorer(6, 6, 6, 6, 6).Yahtzee());
            Assert.AreEqual(0, new YahtzeeScorer(6, 6, 6, 6, 3).Yahtzee());
        }

        [Test]
        public void Score_pair()
        {
            Assert.AreEqual(6, new YahtzeeScorer(3, 4, 3, 5, 6).ScorePair());
            Assert.AreEqual(10, new YahtzeeScorer(5, 3, 3, 3, 5).ScorePair());
            Assert.AreEqual(12, new YahtzeeScorer(5, 3, 6, 6, 5).ScorePair());
        }

        [Test]
        public void Score_two_pairs()
        {
            Assert.AreEqual(16, new YahtzeeScorer(3, 3, 5, 4, 5).TwoPair());
            Assert.AreEqual(0, new YahtzeeScorer(3, 3, 5, 5, 5).TwoPair());
        }

        [Test]
        public void Score_three_of_a_kind()
        {
            Assert.AreEqual(9, new YahtzeeScorer(3, 3, 3, 4, 5).ThreeOfAKind());
            Assert.AreEqual(15, new YahtzeeScorer(5, 3, 5, 4, 5).ThreeOfAKind());
            Assert.AreEqual(0, new YahtzeeScorer(3, 3, 3, 3, 5).ThreeOfAKind());
        }

        [Test]
        public void Score_four_of_a_kind()
        {
            Assert.AreEqual(12, new YahtzeeScorer(3, 3, 3, 3, 5).FourOfAKind());
            Assert.AreEqual(20, new YahtzeeScorer(5, 5, 5, 4, 5).FourOfAKind());
            Assert.AreEqual(0, new YahtzeeScorer(3, 3, 3, 3, 3).FourOfAKind());
        }

        [Test]
        public void Score_small_straight()
        {
            Assert.AreEqual(15, new YahtzeeScorer(1, 2, 3, 4, 5).SmallStraight());
            Assert.AreEqual(15, new YahtzeeScorer(2, 3, 4, 5, 1).SmallStraight());
            Assert.AreEqual(0, new YahtzeeScorer(1, 2, 2, 4, 5).SmallStraight());
        }

        [Test]
        public void Score_large_straight()
        {
            Assert.AreEqual(20, new YahtzeeScorer(6, 2, 3, 4, 5).LargeStraight());
            Assert.AreEqual(20, new YahtzeeScorer(2, 3, 4, 5, 6).LargeStraight());
            Assert.AreEqual(0, new YahtzeeScorer(1, 2, 2, 4, 5).LargeStraight());
        }

        [Test]
        public void Score_full_house()
        {
            Assert.AreEqual(18, new YahtzeeScorer(6, 2, 2, 2, 6).FullHouse());
            Assert.AreEqual(0, new YahtzeeScorer(2, 3, 4, 5, 6).FullHouse());
            Assert.AreEqual(0, new YahtzeeScorer(6, 6, 5, 5, 1).FullHouse());
        }
    }
}


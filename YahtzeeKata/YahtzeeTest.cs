using NUnit.Framework;
using YahtzeeKata;

[TestFixture]
public class UntitledTest
{
    [Test]
    public void Chance_scores_sum_of_all_dice()
    {
        int expected = 15;
        int actual = new Yahtzee(2, 3, 4, 5, 1).Chance();
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(16, new Yahtzee(3, 3, 4, 5, 1).Chance());
    }

    [Test]
    public void Test_1s()
    {
        Assert.IsTrue(new Yahtzee(1, 2, 3, 4, 5).Ones() == 1);
        Assert.AreEqual(2, new Yahtzee(1, 2, 1, 4, 5).Ones());
        Assert.AreEqual(0, new Yahtzee(6, 2, 2, 4, 5).Ones());
        Assert.AreEqual(4, new Yahtzee(1, 2, 1, 1, 1).Ones());
    }

    [Test]
    public void test_2s()
    {
        Assert.AreEqual(4, new Yahtzee(1, 2, 3, 2, 6).Twos());
        Assert.AreEqual(10, new Yahtzee(2, 2, 2, 2, 2).Twos());
    }

    [Test]
    public void test_threes()
    {
        Assert.AreEqual(6, new Yahtzee(1, 2, 3, 2, 3).Threes());
        Assert.AreEqual(12, new Yahtzee(2, 3, 3, 3, 3).Threes());
    }

    [Test]
    public void fours_test()
    {
        Assert.AreEqual(12, new Yahtzee(4, 4, 4, 5, 5).Fours());
        Assert.AreEqual(8, new Yahtzee(4, 4, 5, 5, 5).Fours());
        Assert.AreEqual(4, new Yahtzee(4, 5, 5, 5, 5).Fours());
    }

    [Test]
    public void fives()
    {
        Assert.AreEqual(10, new Yahtzee(4, 4, 4, 5, 5).Fives());
        Assert.AreEqual(15, new Yahtzee(4, 4, 5, 5, 5).Fives());
        Assert.AreEqual(20, new Yahtzee(4, 5, 5, 5, 5).Fives());
    }

    [Test]
    public void sixes_test()
    {
        Assert.AreEqual(0, new Yahtzee(4, 4, 4, 5, 5).Sixes());
        Assert.AreEqual(6, new Yahtzee(4, 4, 6, 5, 5).Sixes());
        Assert.AreEqual(18, new Yahtzee(6, 5, 6, 6, 5).Sixes());
    }

    [Test]
    public void Yahtzee_scores_50()
    {
        int expected = 50;
        int actual = new Yahtzee(4, 4, 4, 4, 4).yahtzee();
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(50, new Yahtzee(6, 6, 6, 6, 6).yahtzee());
        Assert.AreEqual(0, new Yahtzee(6, 6, 6, 6, 3).yahtzee());
    }

    [Test]
    public void one_pair()
    {
        Assert.AreEqual(6, new Yahtzee(3, 4, 3, 5, 6).ScorePair());
        Assert.AreEqual(10, new Yahtzee(5, 3, 3, 3, 5).ScorePair());
        Assert.AreEqual(12, new Yahtzee(5, 3, 6, 6, 5).ScorePair());
    }

    [Test]
    public void two_Pair()
    {
        Assert.AreEqual(16, new Yahtzee(3, 3, 5, 4, 5).TwoPair());
        Assert.AreEqual(0, new Yahtzee(3, 3, 5, 5, 5).TwoPair());
    }

    [Test]
    public void three_of_a_kind()
    {
        Assert.AreEqual(9, new Yahtzee(3, 3, 3, 4, 5).ThreeOfAKind());
        Assert.AreEqual(15, new Yahtzee(5, 3, 5, 4, 5).ThreeOfAKind());
        Assert.AreEqual(0, new Yahtzee(3, 3, 3, 3, 5).ThreeOfAKind());
    }

    [Test]
    public void four_of_a_knd()
    {
        Assert.AreEqual(12, new Yahtzee(3, 3, 3, 3, 5).FourOfAKind());
        Assert.AreEqual(20, new Yahtzee(5, 5, 5, 4, 5).FourOfAKind());
        Assert.AreEqual(0, new Yahtzee(3, 3, 3, 3, 3).FourOfAKind());
    }

    [Test]
    public void smallStraight()
    {
        Assert.AreEqual(15, new Yahtzee(1, 2, 3, 4, 5).SmallStraight());
        Assert.AreEqual(15, new Yahtzee(2, 3, 4, 5, 1).SmallStraight());
        Assert.AreEqual(0, new Yahtzee(1, 2, 2, 4, 5).SmallStraight());
    }

    [Test]
    public void largeStraight()
    {
        Assert.AreEqual(20, new Yahtzee(6, 2, 3, 4, 5).LargeStraight());
        Assert.AreEqual(20, new Yahtzee(2, 3, 4, 5, 6).LargeStraight());
        Assert.AreEqual(0, new Yahtzee(1, 2, 2, 4, 5).LargeStraight());
    }

    [Test]
    public void fullHouse()
    {
        Assert.AreEqual(18, Yahtzee.FullHouse(6, 2, 2, 2, 6));
        Assert.AreEqual(0, Yahtzee.FullHouse(2, 3, 4, 5, 6));
    }
}


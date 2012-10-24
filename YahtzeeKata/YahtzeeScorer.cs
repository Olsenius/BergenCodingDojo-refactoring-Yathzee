using System.Collections.Generic;
using System.Linq;

namespace YahtzeeKata
{
    public class YahtzeeScorer
    {
        private readonly int[] _dice;

        public YahtzeeScorer(int d1, int d2, int d3, int d4, int d5)
        {
            _dice = new int[5];
            _dice[0] = d1;
            _dice[1] = d2;
            _dice[2] = d3;
            _dice[3] = d4;
            _dice[4] = d5;
        }

        public int Ones()
        {
            return OfANumber(1);
        }

        public int Twos()
        {
            return OfANumber(2);
        }

        public int Threes()
        {
            return OfANumber(3);
        }

        public int Fours()
        {
            return OfANumber(4);
        }

        public int Fives()
        {
            return OfANumber(5);
        }

        public int Sixes()
        {
            return OfANumber(6);
        }

        public int ScorePair()
        {
            return SumGroups(2);
        }

        public int TwoPair()
        {
            return SumGroups(2, 2);
        }

        public int ThreeOfAKind()
        {
            return SumGroups(3);
        }

        public int FourOfAKind()
        {
            return SumGroups(4);
        }

        public int SmallStraight()
        {
            return ScoreStraight(new[] { 1, 2, 3, 4, 5 });
        }

        public int LargeStraight()
        {
            return ScoreStraight(new[] { 2, 3, 4, 5, 6 });
        }

        private int ScoreStraight(int[] straight)
        {
            var sortedNumbers = _dice.OrderBy(x => x).ToArray();

            if (sortedNumbers.SequenceEqual(straight))
                return straight.Sum();
            return 0;
        }

        public int FullHouse()
        {
            var groups = _dice.GroupBy(number => number);
            var groupsWithCountOver2 = groups.Where(group => @group.Count() >= 2);

            if (Has3And2Likes(groupsWithCountOver2))
                return _dice.Sum();
            return 0;
        }

        private static bool Has3And2Likes(IEnumerable<IGrouping<int, int>> groupsWithCountOver2)
        {
            return groupsWithCountOver2.Count() == 2 && groupsWithCountOver2.Any(x => x.Count() == 3);
        }

        public int Chance()
        {
            return _dice.Sum();
        }

        public int Yahtzee()
        {
            return SumGroups(5) > 0 ? 50 : 0;
        }

        private int OfANumber(int target)
        {
            return _dice.Count(x => x == target) * target;
        }

        private int SumGroups(int groupSize, int numberOfGroups = 1)
        {
            var groups = _dice.GroupBy(number => number);
            var groupsWithCorrectGroupSize = groups.Where(group => @group.Count() == groupSize);

            if (groupsWithCorrectGroupSize.Count() >= numberOfGroups)
                return groupsWithCorrectGroupSize
                .OrderByDescending(key => key.Key)
                .Take(numberOfGroups)
                .Sum(g => g.Sum());
            return 0;
        }
    }
}

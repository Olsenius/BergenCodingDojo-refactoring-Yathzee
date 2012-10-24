using System.Linq;

namespace YahtzeeKata
{
    public class Yahtzee
    {
        private readonly int[] _dice;

        public Yahtzee(int d1, int d2, int d3, int d4, int d5)
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

        public static int FullHouse(int d1, int d2, int d3, int d4, int d5)
        {
            int[] tallies;
            bool _2 = false;
            int i;
            int _2_at = 0;
            bool _3 = false;
            int _3_at = 0;



            tallies = new int[6];
            tallies[d1 - 1] += 1;
            tallies[d2 - 1] += 1;
            tallies[d3 - 1] += 1;
            tallies[d4 - 1] += 1;
            tallies[d5 - 1] += 1;

            for (i = 0; i != 6; i += 1)
                if (tallies[i] == 2)
                {
                    _2 = true;
                    _2_at = i + 1;
                }

            for (i = 0; i != 6; i += 1)
                if (tallies[i] == 3)
                {
                    _3 = true;
                    _3_at = i + 1;
                }

            if (_2 && _3)
                return _2_at * 2 + _3_at * 3;
            else
                return 0;
        }

        public int Chance()
        {
            return _dice.Sum();
        }

        public int yahtzee()
        {
            return SumGroups(5) > 0 ? 50 : 0;
        }

        private int OfANumber(int target)
        {
            return _dice.Count(x => x == target) * target;
        }

        private int SumGroups(int groupSize, int numberOfGroups = 1)
        {
            var groups = _dice
                .GroupBy(number => number)
                .Where(group => @group.Count() == groupSize);

            if (groups.Count() >= numberOfGroups)
                return groups
                    .OrderByDescending(key => key.Key)
                    .Take(numberOfGroups)
                    .Sum(g => g.Key * groupSize);
            return 0;
        }
    }
}

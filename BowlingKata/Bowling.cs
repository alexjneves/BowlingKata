namespace BowlingKata
{
    public class Bowling
    {
        private const int FramesPerGame = 10;
        private const int MaxScorePerFrame = 10;
        private const int MaxRollsPerGame = 21;

        private readonly int[] _rolls;
        private int _index;

        public Bowling()
        {
            _index = 0;
            _rolls = new int[MaxRollsPerGame];
        }

        public void Roll(int pin)
        {
            _rolls[_index++] = pin;
        }

        public int CalculateScore()
        {
            var score = 0;
            var i = 0;

            for (var frame = 0; frame < FramesPerGame; ++frame)
            {
                score += _rolls[i];
                score += _rolls[i + 1];

                if (IsStrike(i))
                {
                    score += _rolls[i + 2];
                    --i;
                }
                else if (IsSpare(i))
                {
                    score += _rolls[i + 2];
                }

                i += 2;
            }

            return score;
        }

        private bool IsStrike(int i)
        {
            return _rolls[i] == MaxScorePerFrame;
        }

        private bool IsSpare(int i)
        {
            return _rolls[i] + _rolls[i + 1] == MaxScorePerFrame;
        }
        
    }
}

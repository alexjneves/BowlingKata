using BowlingKata.Exceptions;

namespace BowlingKata
{
    public class Frame
    {
        private const int MaxNumberOfRolls = 2;

        private int _rolls;
        private int _score;
        private int _bonus;

        public int First { get; private set; }

        public int Second { get; private set; }

        public Frame()
        {
            _rolls = 0;
            _score = 0;
            _bonus = 0;

            First = 0;
            Second = 0;
        }

        public bool IsComplete()
        {
            return IsStrike() || _rolls == MaxNumberOfRolls;
        }

        public int CalculateScore()
        {
            return _score + _bonus;
        }

        public void Roll(int pin)
        {
            if (IsComplete())
            {
                throw new FrameCompleteException("Frame has been complete, cannot roll again");
            }

            ++_rolls;
            _score += pin;

            if (_rolls == 1)
            {
                First = pin;
            }
            else
            {
                Second = pin;
            }
        }

        public void AddBonus(int bonus)
        {
            _bonus += bonus;
        }

        public bool IsSpare()
        {
            return (_rolls == MaxNumberOfRolls) && (First + Second) == 10;
        }

        public bool IsStrike()
        {
            return (_rolls == 1) && First == 10;
        }

    }
}

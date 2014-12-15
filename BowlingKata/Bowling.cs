using System.Collections.Generic;
using System.Linq;

namespace BowlingKata
{
    public class Bowling
    {
        private const int NumberOfFramesInGame = 10;

        private readonly List<Frame> _frames;

        private Frame _previousFrame;
        private Frame _currentFrame;

        public Bowling()
        {
            _frames = new List<Frame>(NumberOfFramesInGame);

            _currentFrame = new Frame();
            _frames.Add(_currentFrame);
        }

        public void Roll(int pins)
        {
            _currentFrame.Roll(pins);

            if (_currentFrame.IsComplete())
            {
                NextFrame();
            }
        }

        public int CalculateScore()
        {
            return _frames.Sum(frame => frame.CalculateScore());
        }

        private void NextFrame()
        {
            if (_previousFrame != null)
            {
                AddBonus(_previousFrame, _currentFrame);
            }

            if (GameComplete())
            {
                return;
            }

            _previousFrame = _currentFrame;
            _currentFrame = new Frame();

            _frames.Add(_currentFrame);
        }

        private bool GameComplete()
        {
            return _frames.Count == NumberOfFramesInGame;
        }

        private void AddBonus(Frame previous, Frame current)
        {
            var bonus = 0;

            if (previous.IsSpare())
            {
                bonus = current.First;
            }

            if (previous.IsStrike())
            {
                bonus = current.First + current.Second;
            }

            previous.AddBonus(bonus);
        }
    }
}

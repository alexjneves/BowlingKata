using FluentAssertions;
using NUnit.Framework;

namespace BowlingKata.Test
{
    [TestFixture]
    public class BowlingKataTests
    {
        private const int Strike = 10;
        private Bowling _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Bowling();
        }

        [Test]
        public void WhenRollingAllZeroes_ScoreShouldBeZero()
        {
            RollMany(0, 20);

            _game.CalculateScore().Should().Be(0);
        }

        [Test]
        public void WhenRollingAllOnes_ScoreShouldBeTwenty()
        {
            RollMany(1, 20);

            _game.CalculateScore().Should().Be(20);
        }

        [Test]
        public void WhenRollingASpare_ShouldCalculateCorrectScore()
        {
            _game.Roll(6);
            _game.Roll(4);
            _game.Roll(3);

            RollMany(0, 17);

            _game.CalculateScore().Should().Be(16);
        }

        [Test]
        public void WhenRollingAStrike_ShouldCalculateCorrectScore()
        {
            _game.Roll(Strike);

            _game.Roll(6);
            _game.Roll(2);

            _game.CalculateScore().Should().Be(26);
        }

        [Test]
        public void WhenRollingAllStrikes_ShouldCalculateCorrectScore()
        {
            RollMany(Strike, 12);

            _game.CalculateScore().Should().Be(300);
        }

        private void RollMany(int pins, int n)
        {
            for (var i = 0; i < n; ++i)
            {
                _game.Roll(pins);
            }
        }

    }
}

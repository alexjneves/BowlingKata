using System;
using BowlingKata.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace BowlingKata.Test
{
    [TestFixture]
    class FrameTests
    {
        private Frame _frame;

        [SetUp]
        public void SetUp()
        {
            _frame = new Frame();
        }

        [Test]
        public void WhenScoreIsTenAfterTwoRolls_FrameShouldBeASpare()
        {
            _frame.Roll(5);
            _frame.Roll(5);

            _frame.IsSpare().Should().BeTrue();
        }

        [Test]
        public void WhenScoreIsTenAfterOneRoll_FrameShouldBeAStrike()
        {
            _frame.Roll(10);

            _frame.IsStrike().Should().BeTrue();
        }

        [Test]
        public void WhenCalculatingScore_ShouldReturnCorrectValue()
        {
            _frame.Roll(3);
            _frame.Roll(4);

            _frame.CalculateScore().Should().Be(7);
        }

        [Test]
        public void WhenCalculatingScore_WithBonus_ShouldReturnCorrectValue()
        {
            _frame.Roll(7);
            _frame.Roll(1);
            _frame.AddBonus(6);

            _frame.CalculateScore().Should().Be(14);
        }

        [Test]
        public void RollingMoreThanTwice_ShouldThrowException()
        {
            _frame.Roll(0);
            _frame.Roll(0);

            Action roll = () => _frame.Roll(0);

            roll.ShouldThrow<FrameCompleteException>();
        }

        [Test]
        public void AfterRollingTwice_FrameShouldBeComplete()
        {
            _frame.Roll(0);
            _frame.Roll(0);

            _frame.IsComplete().Should().BeTrue();
        }

        [Test]
        public void AfterRollingAStrike_FrameShouldBeComplete()
        {
            _frame.Roll(10);

            _frame.IsComplete().Should().BeTrue();
        }

    }
}

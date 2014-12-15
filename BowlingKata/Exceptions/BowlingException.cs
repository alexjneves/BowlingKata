using System;

namespace BowlingKata.Exceptions
{
    public class BowlingException : Exception
    {
        public BowlingException()
        {
        }

        public BowlingException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BowlingException(string message) : base(message)
        {
        }
    }

    public class FrameCompleteException : BowlingException
    {
        public FrameCompleteException()
        {
        }

        public FrameCompleteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public FrameCompleteException(string message) : base(message)
        {
        }
    }
}

using System;
namespace CardGameAssignment
{
    [Serializable]
    public class SameNumberException : Exception 
    {
        public SameNumberException() { }
        public SameNumberException(string message)
            : base(message) { }
    }

    public class InputOutOfRangeException : Exception
    {
        public InputOutOfRangeException() { }
        public InputOutOfRangeException(string message)
            : base(message) { }
    }

    public class InvalidInputException : Exception
    {
        public InvalidInputException() { }
        public InvalidInputException(string message)
            : base(message) { }
    }
}

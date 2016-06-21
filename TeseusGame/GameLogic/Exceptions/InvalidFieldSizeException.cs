namespace GameLogic.Exceptions
{
    using System;

    public class InvalidFieldSizeException : ArgumentException
    {
        private const string baseMessage = "Invali Field Size!";

        public InvalidFieldSizeException()
            :base (baseMessage)
        {

        }

        public InvalidFieldSizeException(string message)
            :base(message)
        {

        }
    }
}

namespace GameLogic.Exceptions
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class InvalidSizeException : ArgumentException
    {
        private const string baseMessage = "Invali Size!";

        public InvalidSizeException(string message = baseMessage)
            :base (message)
        {

        }
    }
}

namespace GameLogic.Exceptions
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class InvalidSizeException : ArgumentException
    {
        private const string baseMessage = "Invali Size!";

        public InvalidSizeException(string message = baseMessage, Exception inner = null)
            : base(message, inner)
        {

        }
    }
}

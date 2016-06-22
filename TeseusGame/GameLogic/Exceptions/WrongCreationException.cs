namespace GameLogic.Exceptions
{
    using System;

    public class WrongCreationException : InvalidOperationException
    {
        public WrongCreationException(string message = "Using wrong constructor!", Exception inner = null)
            : base(message, inner)
        {

        }
    }
}

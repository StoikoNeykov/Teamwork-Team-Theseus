namespace GameLogic.Exceptions
{
    using System;

    public class WrongCreationException : InvalidOperationException
    {
        public WrongCreationException(string message = GlobalConstant.WrongCreationError, Exception inner = null)
            : base(message, inner)
        {

        }
    }
}

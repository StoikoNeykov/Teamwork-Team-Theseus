namespace GameLogic.Exceptions
{
    using System;

    public class CannotPlaceItHereException : InvalidOperationException
    {
        public CannotPlaceItHereException(string message = "Cannot place it here!", Exception inner = null)
            : base(message, inner)
        {

        }
    }
}

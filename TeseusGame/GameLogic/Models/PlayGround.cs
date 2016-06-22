namespace GameLogic.Models
{
    using Interfaces;

    /// <summary>
    /// Play field
    /// </summary>
    public class PlayGround : Field, IField, IGameElement
    {
        public PlayGround(short width, short height) 
            : base(width, height)
        {
        }

        //TODO all other
    }
}

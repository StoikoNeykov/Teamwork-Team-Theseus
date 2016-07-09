namespace GameLogic.Models
{
    using Interfaces;

    /// <summary>
    /// Play field
    /// </summary>
    public class PlayGround : Field, IField, IGameElement
    {
        public PlayGround(int width, int height) 
            : base(width, height)
        {
        }

        //TODO all other
    }
}

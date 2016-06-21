namespace GameLogic.Models
{
    using Interfaces;

    public class PlayGround : Field, IField
    {
        public PlayGround(int width, int height) 
            : base(width, height)
        {
        }

        //TODO all other
    }
}

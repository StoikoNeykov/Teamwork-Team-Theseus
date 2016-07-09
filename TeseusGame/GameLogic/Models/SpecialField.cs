namespace GameLogic.Models
{
    using Interfaces;

    public class SpecialField : Field, IField, IGameElement
    {
        public SpecialField(int width, int height)
            : base(width, height)
        {
        }
    }
}

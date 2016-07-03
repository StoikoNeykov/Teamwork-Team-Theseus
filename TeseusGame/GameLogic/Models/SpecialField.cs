namespace GameLogic.Models
{
    using Interfaces;

    public class SpecialField : Field, IField, IGameElement
    {
        public SpecialField(short width, short height)
            : base(width, height)
        {
        }
    }
}

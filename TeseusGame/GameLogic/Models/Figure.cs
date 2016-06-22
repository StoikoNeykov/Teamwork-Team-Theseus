namespace GameLogic.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// On playgraound blocks
    /// </summary>
    public class Figures : Block, IBlock , IFigure, IGameElement
    {
        public Figures(short width, short height, short top, short left, FigureForms shape) 
            : base(width, height, top, left, shape)
        {
        }

        //TODO if needed
        public bool Rotate(short rotate)
        {
            return false;
        }

    }
}

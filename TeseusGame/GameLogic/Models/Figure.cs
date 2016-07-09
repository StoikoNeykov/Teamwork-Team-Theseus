namespace GameLogic.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// On playgraound blocks
    /// </summary>
    public class Figures : Block, IBlock, IFigure, IGameElement
    {
        public Figures(int width, int height, int top, int left, FigureFormsType shape, MaterialType material)
            : base(width, height, top, left, shape, material)
        {
        }

    }
}

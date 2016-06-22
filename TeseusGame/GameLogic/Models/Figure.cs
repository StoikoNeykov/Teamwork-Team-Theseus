namespace GameLogic.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// On playgraound blocks
    /// </summary>
    public abstract class Figures : Block, IBlock , IFigure, IGameElement
    {
        #region Constructors

        public Figures(short width, short height, short top, short left, FigureForms shape) 
            : base(width, height, top, left, shape)
        {
        }

        #endregion

        #region Public Methods

        public abstract bool Rotate(short rotate);

        #endregion
    }
}

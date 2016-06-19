namespace GameLogic.Models
{
    using Interfaces;

    public abstract class Figures : Block, IBlock , IFigure
    {
        #region Constructors

        public Figures(short width, short height, short top, short left, short shape) 
            : base(width, height, top, left, shape)
        {
        }

        #endregion

        #region Public Methods

        public abstract bool Rotate(short rotate);

        #endregion
    }
}

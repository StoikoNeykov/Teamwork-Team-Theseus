namespace GameLogic.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Outside undestructable blocks
    /// </summary>
    public class WallBlock : Block, IBlock, IGameElement
    {
        public WallBlock(short width, short height, short top, short left, FigureForms shape)
     : base(width, height, top, left, shape)
        {
        }
    }
}

namespace GameLogic.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Outside undestructable blocks
    /// </summary>
    public class WallBlock : Block, IBlock, IGameElement
    {
        public WallBlock(int width, int height, int top, int left, FigureFormsType shape)
     : base(width, height, top, left, shape, MaterialType.Solid)
        {
        }
    }
}

namespace GameLogic.Models
{
    using Interfaces;

    public class WallBlock : Block, IBlock
    {
        public WallBlock(short width, short height, short top, short left, short shape)
     : base(width, height, top, left, shape)
        {
        }
    }
}

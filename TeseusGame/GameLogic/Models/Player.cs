namespace GameLogic.Models
{
    using Interfaces;

    /// <summary>
    /// Represent player 
    /// </summary>
    public class Player : GameElement, IGameElement, IPlayer, IBlock
    {
        private bool[,] shape = { { true } };

        public Player()
            : base(1, 1)
        {
        }


        public int Left { get; set; }

        public bool[,] Shape
        {
            get
            {
                return shape;
            }
        }

        public int Top { get; set; }

    }
}

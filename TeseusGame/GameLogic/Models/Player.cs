namespace GameLogic.Models
{
    using System;
    using Enumerations;
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
            this.ViewDirection = Directions.Up;
            this.Material = MaterialType.Solid;
        }

        public MaterialType Material { get; set; }

        public Directions ViewDirection { get; set; }

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

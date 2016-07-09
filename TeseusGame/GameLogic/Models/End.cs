namespace GameLogic.Models
{
    using System;
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Represent target location
    /// </summary>
    public class End : GameElement, IGameElement, IBlock
    {
        private bool[,] shape = { { true } };

        public End()
            : base(1, 1)
        {
            this.Material = MaterialType.Empty;
        }

        public MaterialType Material { get; set; }

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

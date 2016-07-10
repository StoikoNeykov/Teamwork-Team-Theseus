namespace GameLogic.Models
{
    using Interfaces;
    using Exceptions;
    using System;

    /// <summary>
    /// Represent fields on the UI - playgrouds 
    /// </summary>
    public abstract class Field : GameElement, IField, IGameElement
    {
        private IBlock[,] matrix;

        public Field(int width, int height)
            : base(width, height)
        {
            this.Matrix = new IBlock[width, height];
        }

        // readonly coz fields cannot be resized - only constructor ca set their size
        public IBlock[,] Matrix
        {
            get
            {
                return this.matrix;
            }
            private set
            {
                this.matrix = value;
            }
        }

        public int[,] GetFlattenMatrix()
        {
            var result = new int[this.Width, this.Height];
            for (int col = 0; col < this.Width; col++)
            {
                for (int row = 0; row < this.Height; row++)
                {
                    result[col, row] = (int)this.Matrix[col, row].Material;
                }
            }

            return result;
        }
    }
}

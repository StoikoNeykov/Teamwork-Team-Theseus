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
        private IGameElement[,] matrix;

        public Field(int width, int height)
            : base(width, height)
        {
            this.Matrix = new IGameElement[width, height];
        }

        // readonly coz fields cannot be resized - only constructor ca set their size
        public IGameElement[,] Matrix
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

    }
}

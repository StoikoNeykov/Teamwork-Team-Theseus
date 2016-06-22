namespace GameLogic.Models
{
    using Interfaces;
    using Exceptions;
    using System;

    /// <summary>
    /// Represent fields on the UI - playgrouds 
    /// </summary>
    public abstract class Field :GameElement, IField, IGameElement
    {
        #region Fields

        private int[,] matrix;

        #endregion

        #region Constructors

        public Field(short width, short height)
            :base(width, height)
        {
            this.Matrix = new int[width, height];
        }

        #endregion

        // readonly coz fields cannot be resized - only constructor ca set their size
        #region Properties

        public int[,] Matrix
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

        #endregion
    }
}

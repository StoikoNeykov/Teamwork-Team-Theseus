namespace GameLogic.Models
{
    using Interfaces;
    using Exceptions;
    using System;

    /// <summary>
    /// Represent fields on the UI - playgrouds 
    /// </summary>
    public abstract class Field : IField
    {
        #region Constants

        private const int MaxFieldWidth = 10;

        private const int MaxFieldHeight = 20;

        #endregion

        #region Fields

        private int width;

        private int height;

        private int[,] matrix;

        #endregion

        #region Constructors

        public Field(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.Matrix = new int[width, height];
        }

        #endregion

        // readonly coz fields cannot be resized - only constructor ca set their size
        #region Properties

        public int Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0 || value > MaxFieldWidth)
                {
                    throw new InvalidFieldSizeException();
                }

                this.width = value;
            }
        }

        public int Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0 || value > MaxFieldHeight)
                {
                    throw new InvalidFieldSizeException();
                }

                this.height = value;
            }
        }

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

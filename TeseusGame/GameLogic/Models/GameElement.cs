namespace GameLogic.Models
{
    using Interfaces;
    using Exceptions;

    /// <summary>
    /// Top parent class
    /// </summary>
    public abstract class GameElement : IGameElement
    {
        private const int MaxWidth = 15;

        private const int MaxHeight = 30;

        public GameElement(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        private int width;

        private int height;

        public int Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                if (value <= 0 || value > MaxWidth)
                {
                    throw new InvalidSizeException();
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
            protected set
            {
                if (value <= 0 || value > MaxHeight)
                {
                    throw new InvalidSizeException();
                }

                this.height = value;
            }
        }

    }
}
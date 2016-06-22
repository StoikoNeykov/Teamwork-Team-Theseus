namespace GameLogic.Models
{
    using Interfaces;
    using Exceptions;

    /// <summary>
    /// Top parent class
    /// </summary>
    public abstract class GameElement : IGameElement
    {
        private const short MaxWidth = 15;

        private const short MaxHeight = 30;

        public GameElement(short width, short height)
        {
            this.Width = width;
            this.Height = height;
        }

        private short width;

        private short height;

        public short Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0 || value > MaxWidth)
                {
                    throw new InvalidSizeException();
                }

                this.width = value;
            }
        }


        public short Height
        {
            get
            {
                return this.height;
            }
            set
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
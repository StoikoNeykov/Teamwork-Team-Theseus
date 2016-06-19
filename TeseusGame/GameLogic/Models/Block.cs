namespace GameLogic.Models
{
    public class Block
    {
        #region fields

        private short width;

        private short height;

        private short top;

        private short left;

        private bool[,] shape;

        #endregion

        #region Constructors
        public Block(short width, short height, short top, short left, short shape)
        {
            this.Widht = width;
            this.Height = height;
            this.Top = top;
            this.Left = left;
            this.Shape = GetShape(shape);
        }
        #endregion

        //TODO validations 
        #region Properties

        public short Widht
        {
            get
            {
                return this.width;
            }
            set
            {
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
                this.height = value;
            }
        }

        public short Top
        {
            get
            {
                return this.top;
            }
            set
            {
                this.top = value;
            }
        }

        public short Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
            }
        }

        // realonly for now 
        public bool[,] Shape
        {
            get
            {
                return this.shape;
            }
            private set
            {
                this.shape = value;
            }
        }
        #endregion

        //TODO add shapes in cases
        #region Private Methods

        private bool[,] GetShape(short shape)
        {
            bool[,] result;
            switch (shape)
            {
                case 1:
                case 2:
                case 3:

                default:
                    break;
            }

            return result;
        }

        #endregion
    }


}

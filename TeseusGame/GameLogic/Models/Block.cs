namespace GameLogic.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// All kind of ingame blocks
    /// </summary>
    public abstract class Block : GameElement, IBlock, IGameElement
    {
        private int top;

        private int left;

        public bool[,] shape;

        private bool solid, platform, ladder;

        public Block(int width, int height, int top, int left, FigureFormsType shape, MaterialType material)
            : base(width, height)
        {
            this.Top = top;
            this.Left = left;
            this.Shape = GetShape(shape);
            this.Material = material;

        }

        //TODO validations 

        public int Top
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

        public int Left
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

        public MaterialType Material { get; set; }

        public GlobalConstant Density { get; private set; }

        //TODO check if correct!

        private bool[,] GetShape(FigureFormsType shape)
        {
            int shapeToInt = (int)shape;
            bool[,] result;
            switch (shapeToInt)
            {
                case 0: //"straight":
                    this.Width = 1;
                    this.Height = 4;
                    this.top = 0;
                    this.left = 5;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[0, 1] = true;
                    result[0, 2] = true;
                    result[0, 3] = true;

                    this.Shape = result;
                    break;

                case 1: //"Square":
                    this.Width = 2;
                    this.Height = 2;
                    this.top = 0;
                    this.left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[0, 1] = true;
                    result[1, 0] = true;
                    result[1, 1] = true;

                    this.Shape = result;
                    break;

                case 2: //"cornerleft":
                    this.Width = 3;
                    this.Height = 2;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[1, 0] = true;
                    result[2, 0] = true;
                    result[0, 1] = true;
                    result[1, 1] = false;
                    result[2, 1] = false;

                    this.Shape = result;
                    break;

                case 3: //"cornerright":
                    this.Width = 3;
                    this.Height = 2;
                    this.top = 0;
                    this.left = 4;
                    result = new bool[Width, Height];

                    result[0, 0] = true;
                    result[1, 0] = true;
                    result[2, 0] = true;
                    result[0, 1] = false;
                    result[1, 1] = false;
                    result[2, 1] = true;

                    this.Shape = result;
                    break;

                case 4: //"cross":
                    this.Width = 3;
                    this.Height = 2;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[1, 0] = true;
                    result[2, 0] = true;
                    result[0, 1] = false;
                    result[1, 1] = true;
                    result[2, 1] = false;

                    this.Shape = result;
                    break;

                case 5: //"zigzag1":
                    this.Width = 2;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = false;
                    result[1, 0] = true;
                    result[0, 1] = true;
                    result[1, 1] = true;
                    result[0, 2] = true;
                    result[1, 2] = false;

                    this.Shape = result;
                    break;

                case 6: //"zigzag2":
                    this.Width = 2;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[1, 0] = false;
                    result[0, 1] = true;
                    result[1, 1] = true;
                    result[0, 2] = false;
                    result[1, 2] = true;

                    this.Shape = result;
                    break;

                case 7: //"zero":
                    this.Width = 1;
                    this.Height = 1;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;

                    this.Shape = result;
                    break;

                case 8: //"cross2":
                    this.Width = 3;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = false;
                    result[0, 1] = true;
                    result[0, 2] = false;
                    result[1, 0] = true;
                    result[1, 1] = true;
                    result[1, 2] = true;
                    result[2, 0] = false;
                    result[2, 1] = true;
                    result[2, 2] = false;

                    this.Shape = result;
                    break;

                case 9: //"rectangle1":
                    this.Width = 3;
                    this.Height = 2;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[0, 1] = false;
                    result[1, 0] = true;
                    result[1, 1] = true;
                    result[2, 0] = true;
                    result[2, 1] = true;

                    this.Shape = result;
                    break;

                case 10: //"cross3":
                    this.Width = 3;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = false;
                    result[0, 1] = true;
                    result[0, 2] = false;
                    result[1, 0] = false;
                    result[1, 1] = true;
                    result[1, 2] = false;
                    result[2, 0] = true;
                    result[2, 1] = true;
                    result[2, 2] = true;

                    this.Shape = result;
                    break;

                case 11: //"zigzag3":
                    this.Width = 3;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = false;
                    result[1, 0] = true;
                    result[0, 1] = true;
                    result[1, 1] = true;
                    result[0, 2] = true;
                    result[1, 2] = false;
                    result[2, 0] = true;
                    result[2, 1] = false;
                    result[2, 2] = false;

                    this.Shape = result;
                    break;

                case 12: //"zigzag4":
                    this.Width = 3;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = false;
                    result[1, 0] = true;
                    result[0, 1] = false;
                    result[1, 1] = true;
                    result[0, 2] = true;
                    result[1, 2] = true;
                    result[2, 0] = true;
                    result[2, 1] = false;
                    result[2, 2] = false;

                    this.Shape = result;
                    break;

                case 13: //"rectangle2":
                    this.Width = 3;
                    this.Height = 2;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[0, 1] = true;
                    result[1, 0] = true;
                    result[1, 1] = false;
                    result[2, 0] = true;
                    result[2, 1] = true;

                    this.Shape = result;
                    break;

                case 14: //"cross4":
                    this.Width = 3;
                    this.Height = 3;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = false;
                    result[0, 1] = true;
                    result[0, 2] = true;
                    result[1, 0] = true;
                    result[1, 1] = true;
                    result[1, 2] = false;
                    result[2, 0] = false;
                    result[2, 1] = true;
                    result[2, 2] = false;

                    this.Shape = result;
                    break;

                case 15: //"linecornerleft1":
                    this.Width = 2;
                    this.Height = 4;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[0, 1] = false;
                    result[0, 2] = false;
                    result[0, 3] = false;
                    result[1, 0] = true;
                    result[1, 1] = true;
                    result[1, 2] = true;
                    result[1, 3] = true;

                    this.Shape = result;
                    break;

                case 16: //"linecornerleft2":
                    this.Width = 2;
                    this.Height = 4;
                    this.Top = 0;
                    this.Left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = false;
                    result[0, 1] = true;
                    result[0, 2] = false;
                    result[0, 3] = false;
                    result[1, 0] = true;
                    result[1, 1] = true;
                    result[1, 2] = true;
                    result[1, 3] = true;

                    this.Shape = result;
                    break;

                case 17: //"straight2":
                    this.Width = 1;
                    this.Height = 5;
                    this.top = 0;
                    this.left = 5;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[0, 1] = true;
                    result[0, 2] = true;
                    result[0, 3] = true;
                    result[0, 4] = true;

                    this.Shape = result;
                    break;


                case 18: //"zigzag5":
                    this.Width = 2;
                    this.Height = 4;
                    this.top = 0;
                    this.left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = false;
                    result[0, 1] = true;
                    result[0, 2] = true;
                    result[0, 3] = true;
                    result[1, 0] = true;
                    result[1, 1] = true;
                    result[1, 2] = false;
                    result[1, 3] = false;


                    this.Shape = result;
                    break;

                case 19: //"angle1":
                    this.Width = 3;
                    this.Height = 3;
                    this.top = 0;
                    this.left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[0, 1] = false;
                    result[0, 2] = false;
                    result[1, 0] = true;
                    result[1, 1] = false;
                    result[1, 2] = false;
                    result[2, 0] = true;
                    result[2, 1] = true;
                    result[2, 2] = true;


                    this.Shape = result;
                    break;

                case 20: //"angle2":
                    this.Width = 2;
                    this.Height = 2;
                    this.top = 0;
                    this.left = 4;
                    result = new bool[Width, Height];
                    result[0, 0] = true;
                    result[0, 1] = true;
                    result[1, 0] = false;
                    result[1, 1] = true;

                    this.Shape = result;
                    break;

                default:
                    throw new System.ArgumentException("Invalid block code");
            }

            return result;
        }

    }

}

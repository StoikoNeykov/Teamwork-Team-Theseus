namespace GameLogic.Factory
{
    using System;

    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Factory
    /// </summary>
    public class LevelMaker
    {
        public virtual IField NewLivel()
        {
            Random rng = new Random();

            var creator = new Creator();

            var playground = creator.CreateField(CreationType.Playground);

            var wall = creator.CreateBlock(CreationType.WallBlock);
            SetOuterWalls(playground, wall);

            var player = creator.CreatePlayer();
            player.Top = 1;
            player.Left = rng.Next(playground.Width - 2) + 1;
            playground.Matrix[player.Top, player.Left] = player;

            var end = creator.CreateBlock(CreationType.End);
            end.Top = playground.Height - 2;
            end.Left = rng.Next(playground.Width - 2) + 1;
            playground.Matrix[end.Top, end.Left] = end;

            for (int i = 0; i < GlobalConstant.figuresOnThePlayground; i++)
            {
                var figure = GetRandomFigure(creator);
                if (!PlaceFigureOnPlayground(playground, figure))
                {
                    i--;
                }
            }

            return playground;
        }

        public virtual IField NewSpecialField()
        {
            var creator = new Creator();
            var result = creator.CreateField(CreationType.SpecialField);
            return result;
        }

        public virtual void SetOuterWalls(IField playground, IBlock wallBlock)
        {
            for (int i = 0; i < playground.Width; i++)
            {
                if (i == 0 || i == playground.Width - 1)
                {
                    for (int j = 0; j < playground.Height; j++)
                    {
                        playground.Matrix[i, j] = wallBlock;
                    }

                }
                else
                {
                    playground.Matrix[i, 0] = wallBlock;
                    playground.Matrix[i, playground.Height - 1] = wallBlock;
                }
            }
        }

        public virtual IFigure GetRandomFigure(ICreator creator)
        {
            var forms = Enum.GetValues(typeof(FigureFormsType));
            var mats = Enum.GetValues(typeof(MaterialType));
            Random rng = new Random();

            var randomForm = (FigureFormsType)forms.GetValue(rng.Next(forms.Length));
            //avoid 0 and 1 coz special values (if i understand right team plan :D)
            var randomMat = (MaterialType)mats.GetValue(rng.Next(mats.Length - 2) + 2);
            var result = creator.CreateFigure(CreationType.Figure, randomForm, randomMat);
            return result;
        }

        public virtual bool PlaceFigureOnPlayground(IField playground, IFigure figure)
        {
            Random rng = new Random();
            for (int i = 0; i < GlobalConstant.maxTriesToPlaceFigure; i++)
            {
                // -2 and +1 make sure figure wont try to be set on outer walls
                var curentTop = rng.Next(playground.Height - figure.Height - 2) + 1;
                var curentLeft = rng.Next(playground.Width - figure.Width - 2) + 1;
                if (ValidatePosition(playground, figure, curentTop, curentLeft))
                {
                    figure.Top = (int)curentTop;
                    figure.Left = (int)curentLeft;
                    var rows = figure.Shape.GetLength(0);
                    var cols = figure.Shape.GetLength(1);

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (figure.Shape[row, col] == true)
                            {
                                playground.Matrix[curentTop + row, curentLeft + col] = figure;
                            }
                        }
                    }

                    return true;
                }

            }

            return false;
        }

        public virtual bool ValidatePosition(IField playground, IFigure figure, int curentTop, int curentLeft)
        {
            var rows = figure.Shape.GetLength(0);
            var cols = figure.Shape.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!(figure.Shape[row, col] == true && playground.Matrix[curentTop + row, curentLeft + col] == null))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

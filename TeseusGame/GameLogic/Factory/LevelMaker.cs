namespace GameLogic.Factory
{
    using System;
    using System.Collections.Generic;

    using Enumerations;
    using Interfaces;
    using Models;

    /// <summary>
    /// Factory
    /// </summary>
    public class LevelMaker
    {
        public virtual IList<IGameElement> NewLivel()
        {
            Random rng = new Random();
            IList<IGameElement> level = new List<IGameElement>();

            var creator = new Creator();

            var playground = (PlayGround)creator.Create(CreationType.Playground);

            var wall = creator.Create(CreationType.WallBlock);
            SetOuterWalls(playground, wall);

            var player = creator.Create(CreationType.Player);
            playground.Matrix[1, rng.Next(playground.Width - 2) + 1] = player;

            var end = creator.Create(CreationType.End);
            playground.Matrix[playground.Height - 2, rng.Next(playground.Width - 2) + 1] = end;

            for (int i = 0; i < GlobalConstant.figuresOnThePlayground; i++)
            {
                var figure = GetRandomFigure(creator);
                if (!PlaceFigureOnPlayground(playground, figure))
                {
                    i--;
                }
            }

            level.Add(playground);

            var special = creator.Create(CreationType.SpecialField);

            // TODO figure that been show in that field and set it on

            level.Add(special);

            return level;
        }

        private static void SetOuterWalls(PlayGround playground, IGameElement wallBlock)
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

        private static IFigure GetRandomFigure(Creator creator)
        {
            var arr = Enum.GetValues(typeof(FigureFormsType));
            Random rng = new Random();
            var randomForm = (FigureFormsType)arr.GetValue(rng.Next(arr.Length));
            var result = creator.Create(CreationType.Figure, randomForm);
            return (IFigure)result;
        }

        private static bool PlaceFigureOnPlayground(PlayGround playground, IFigure figure)
        {
            Random rng = new Random();
            for (int i = 0; i < GlobalConstant.maxTriesToPlaceFigure; i++)
            {
                // -2 and +1 make sure figure wont try to be set on outer walls
                var curentTop = rng.Next(playground.Height - figure.Height - 2) + 1;
                var curentLeft = rng.Next(playground.Width - figure.Width - 2) + 1;
                if (ValidatePosition(playground, figure, curentTop, curentLeft))
                {
                    figure.Top = (short)curentTop;
                    figure.Left = (short)curentLeft;
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

        private static bool ValidatePosition(PlayGround playground, IFigure figure, int curentTop, int curentLeft)
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

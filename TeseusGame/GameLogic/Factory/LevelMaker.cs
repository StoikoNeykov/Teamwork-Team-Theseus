namespace GameLogic.Factory
{
    using System;
    using System.Collections.Generic;

    using Enumerations;
    using Interfaces;
    using Models;

    /// <summary>
    /// Facada
    /// </summary>
    public class LevelMaker
    {
        private const int maxTriesToPlaceFigure = 50;

        /// <summary>
        /// WARNING: If too many figures been set endless loop is posible!!! 
        /// </summary>
        private const int figuresOnThePlayground = 15;

        public virtual IList<IGameElement> NewLivel()
        {
            Random rng = new Random();
            IList<IGameElement> level = new List<IGameElement>();

            // instance of constructor
            var creator = new Creator();

            // curent playground
            var playground = (PlayGround)creator.Create(CreationType.Playground);

            // set walls 
            var element = creator.Create(CreationType.WallBlock);
            SetOuterWalls(playground, element);

            // set random player position on line 1 (0 is wall)
            var player = creator.Create(CreationType.Player);
            playground.Matrix[1, rng.Next(playground.Width - 2) + 1] = player;

            // set random end position on last line before wall
            var end = creator.Create(CreationType.End);
            playground.Matrix[playground.Height - 2, rng.Next(playground.Width - 2) + 1] = end;

            // create random figures and put them on the ground
            for (int i = 0; i < figuresOnThePlayground; i++)
            {
                var figure = GetRandomFigure(creator);
                if (!PlaceFigureOnPlayground(playground, figure))
                {
                    i--;
                }
            }

            level.Add(playground);

            // create specialField
            var special = creator.Create(CreationType.SpecialField);

            // TODO figure that been show in that field and set it on

            level.Add(special);

            return level;
        }

        /// <summary>
        /// Place same wallBlock on each of outer walls cells
        /// </summary>
        /// <param name="wallBlock">WallBlocks with FigureForm.Zero (1x1 square)</param>
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
            var arr = Enum.GetValues(typeof(FigureForms));
            Random rng = new Random();
            var randomForm = (FigureForms)arr.GetValue(rng.Next(arr.Length));
            var result = creator.Create(CreationType.Figure, randomForm);
            return (IFigure)result;
        }

        /// <summary>
        /// Make X tries to place IFigure on the playgrounds
        /// </summary>
        /// <returns>return true if success</returns>
        private static bool PlaceFigureOnPlayground(PlayGround playground, IFigure figure)
        {
            Random rng = new Random();
            for (int i = 0; i < maxTriesToPlaceFigure; i++)
            {
                // -2 and +1 make sure figure wont try to be set on outer walls
                var curentTop = rng.Next(playground.Height - figure.Height - 2) + 1;
                var curentLeft = rng.Next(playground.Width - figure.Width - 2) + 1;
                if (ValidatePosition(playground, figure, curentTop, curentLeft))
                {
                    figure.Top = (short)curentTop;
                    figure.Left = (short)curentLeft;
                    // J -> rows, K -> cols
                    for (int j = 0; j < figure.Shape.GetLength(0); j++)
                    {
                        for (int k = 0; k < figure.Shape.GetLength(1); k++)
                        {
                            if (figure.Shape[j, k] == true)
                            {
                                // TODO debbug this rows and cols are right set
                                playground.Matrix[curentTop + j, curentLeft + k] = figure;
                            }
                        }
                    }

                    return true;
                }

            }

            return false;
        }

        // TODO debbug this rows and cols are right set 
        /// <summary>
        /// Validate curent figure can be place on the playground with curentTop and curentLeft
        /// </summary>
        /// <returns>return true if figure can be placed on this coords successfuly</returns>
        private static bool ValidatePosition(PlayGround playground, IFigure figure, int curentTop, int curentLeft)
        {
            for (int j = 0; j < figure.Shape.GetLength(0); j++)
            {
                for (int k = 0; k < figure.Shape.GetLength(1); k++)
                {
                    if (!(figure.Shape[j, k] == true && playground.Matrix[curentTop + j, curentLeft + k] == null))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

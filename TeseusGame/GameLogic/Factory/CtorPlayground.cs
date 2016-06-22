namespace GameLogic.Factory
{
    using System;
    using System.Collections.Generic;

    using Extensions;
    using Interfaces;
    using Models;

    public class CtorPlayground : Factory, ICreator
    {
        private const int FiguresPerLevel = 15;

        private const int StandartPlaygroundWidth = 10;

        private const int StandartPlaygroundHeight = 20;

        public override IList<IGameElement> Create(short count = 1)
        {
            var result = new List<IGameElement>();
            var playground = new PlayGround(StandartPlaygroundWidth + 2, StandartPlaygroundHeight + 2);

            var wallmaker = new CtorWallBlock();
            var wallElements = wallmaker.Create(StandartPlaygroundHeight * 2 + StandartPlaygroundWidth * 2 + 4);
            this.MakeWalls(playground, wallElements);

            var blockmaker = new CtorBlock();
            var figures = blockmaker.Create(FiguresPerLevel);
            this.PlaceFigures(playground, figures);
            // TODO

            result.Add(playground);
            return result;
        }

        private void PlaceFigures(PlayGround playground, IList<IGameElement> figures)
        {
            figures.ForEach(x => PlaceBlock(x));
        }

        private void PlaceBlock(IGameElement element)
        {
            var rng = new Random();
            while (true)
            {
                bool success = false;
                var width = rng.Next(1, StandartPlaygroundWidth - element.Width);
                var height = rng.Next(1, StandartPlaygroundHeight - element.Height);

                // TODO implement put element on the playground with that top and that left
                // if cant repeat

                if (success)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Place wallBlocks on the edges on the playground
        /// </summary>
        private void MakeWalls(PlayGround playground, IList<IGameElement> wallElements)
        {
            int blockIndex = 0;

            for (int i = 0; i <= StandartPlaygroundHeight + 1; i++)
            {
                if (i == 0 || i == StandartPlaygroundHeight + 1)
                {
                    for (int j = 0; j <= StandartPlaygroundWidth + 1; j++)
                    {
                        playground.Matrix[i, j] = wallElements[blockIndex];
                        blockIndex++;
                    }
                }
                else
                {
                    playground.Matrix[i, 0] = wallElements[blockIndex];
                    blockIndex++;
                    playground.Matrix[i, StandartPlaygroundWidth + 1] = wallElements[blockIndex];
                    blockIndex++;
                }
            }
        }
    }
}

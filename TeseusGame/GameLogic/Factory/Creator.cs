namespace GameLogic.Factory
{
    using Exceptions;
    using Enumerations;
    using Interfaces;
    using Models;

    public class Creator : ICreator
    {
        public virtual IField CreateField(CreationType creation)
        {
            switch (creation)
            {

                case CreationType.Playground:
                    return new PlayGround(GlobalConstant.StandarPlaygroundtWidth + 2, GlobalConstant.StandartPlaygroundHeight + 2);
                case CreationType.SpecialField:
                    return new SpecialField(GlobalConstant.SpecialFieldWidth, GlobalConstant.SpecialFieldHeight);
                default:
                    throw new WrongCreationException();
            }
        }

        public virtual IFigure CreateFigure(CreationType creation = CreationType.Figure,
                                                FigureFormsType shape = FigureFormsType.Zero,
                                                MaterialType material = MaterialType.Wood)
        {
            switch (creation)
            {
                case CreationType.Figure:
                    return new Figures(1, 1, 0, 0, shape, material);
                default:
                    throw new WrongCreationException();
            }
        }

        public virtual IBlock CreateBlock(CreationType creation, FigureFormsType shape = FigureFormsType.Zero)
        {
            switch (creation)
            {

                case CreationType.WallBlock:
                    return new WallBlock(1, 1, 0, 0, shape);
                case CreationType.End:
                    return new End();
                default:
                    throw new WrongCreationException();
            }

        }

        public virtual IPlayer CreatePlayer(CreationType creation = CreationType.Player, FigureFormsType shape = FigureFormsType.Zero)
        {
            switch (creation)
            {
                case CreationType.Player:
                    return new Player();
                default:
                    throw new WrongCreationException();
            }
        }
    }
}

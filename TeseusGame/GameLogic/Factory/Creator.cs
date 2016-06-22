namespace GameLogic.Factory
{
    using Exceptions;
    using Enumerations;
    using Interfaces;
    using Models;

    public class Creator
    {
        private const int StandartWidth = 4;

        private const int StandartHeight = 4;

        private const int SpecialWidth = 4;

        private const int SpecialHeight = 4;

        public virtual IGameElement Create(CreationType creation, FigureForms shape = FigureForms.Zero)
        {
            IGameElement result;

            switch (creation)
            {
                case CreationType.WallBlock:
                    result = new WallBlock(1, 1, 0, 0, FigureForms.Zero);
                    break;
                case CreationType.Figure:
                    result = new Figures(1, 1, 0, 0, shape);
                    break;
                case CreationType.Playground:
                    result = new PlayGround(StandartWidth + 2, StandartHeight + 2);
                    break;
                case CreationType.SpecialField:   
                    result = new SpecialField(SpecialWidth, SpecialHeight);
                    break;
                default:
                    throw new WrongCreationException();
            }

            return result;
        }
    }
}

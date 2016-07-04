namespace GameLogic.Factory
{
    using Exceptions;
    using Enumerations;
    using Interfaces;
    using Models;

    public class Creator
    {
        public virtual IGameElement Create(CreationType creation, FigureFormsType shape = FigureFormsType.Zero)
        {
            IGameElement result;

            switch (creation)
            {
                case CreationType.Figure:
                    result = new Figures(1, 1, 0, 0, shape);
                    break;
                case CreationType.Playground:
                    result = new PlayGround(GlobalConstant.StandarPlaygroundtWidth + 2, GlobalConstant.StandartPlaygroundHeight + 2);
                    break;
                case CreationType.WallBlock:
                    result = new WallBlock(1, 1, 0, 0, FigureFormsType.Zero);
                    break;
                case CreationType.End:
                    result = new End();
                    break;
                case CreationType.Player:
                    result = new Player();
                    break;
                case CreationType.SpecialField:
                    result = new SpecialField(GlobalConstant.SpecialFieldWidth, GlobalConstant.SpecialFieldHeight);
                    break;
                default:
                    throw new WrongCreationException();
            }

            return result;
        }
    }
}

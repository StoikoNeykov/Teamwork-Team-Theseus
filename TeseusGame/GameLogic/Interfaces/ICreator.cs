namespace GameLogic.Interfaces
{
    using Enumerations;

    public interface ICreator
    {
        IField CreateField(CreationType creation);

        IFigure CreateFigure(CreationType creation, FigureFormsType shape, MaterialType material);

        IBlock CreateBlock(CreationType creation, FigureFormsType shape);

        IPlayer CreatePlayer(CreationType creation, FigureFormsType shape);
    }
}

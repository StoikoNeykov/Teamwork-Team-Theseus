namespace GameLogic.Interfaces
{
    /// <summary>
    /// Figures are rotatable and movable game items
    /// </summary>
    public interface IFigure : IBlock, IGameElement
    {
        bool Rotate(int rotate);
        // TODO Add moving
    }
}

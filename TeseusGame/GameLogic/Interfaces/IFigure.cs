namespace GameLogic.Interfaces
{
    /// <summary>
    /// Figures are rotatable and movable game items
    /// </summary>
    public interface IFigure
    {
        bool Rotate(short rotate);
        // TODO Add moving
    }
}

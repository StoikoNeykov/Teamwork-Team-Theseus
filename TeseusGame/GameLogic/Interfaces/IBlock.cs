namespace GameLogic.Interfaces
{
    /// <summary>
    /// if exsist block have to know shape and location
    /// </summary>
    public interface IBlock
    {
        short Widht { get; }
        short Height { get; }
        short Top { get; }
        short Left { get; }
        bool[,] Shape { get; }
    }
}

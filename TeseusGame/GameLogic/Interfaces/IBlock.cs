namespace GameLogic.Interfaces
{
    /// <summary>
    /// if exsist block have to know shape and location
    /// </summary>
    public interface IBlock : IGameElement
    {
        short Top { get; }
        short Left { get; }
        bool[,] Shape { get; }
    }
}

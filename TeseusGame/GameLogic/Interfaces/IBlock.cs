namespace GameLogic.Interfaces
{
    /// <summary>
    /// if exsist block have to know shape and location
    /// </summary>
    public interface IBlock : IGameElement
    {
        int Top { get; set; }
        int Left { get; set; }
        bool[,] Shape { get; }
    }
}

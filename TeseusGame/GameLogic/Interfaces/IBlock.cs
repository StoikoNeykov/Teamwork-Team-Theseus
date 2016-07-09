namespace GameLogic.Interfaces
{

    using Enumerations;

    /// <summary>
    /// if exsist block have to know shape and location
    /// </summary>
    public interface IBlock : IGameElement
    {
        int Top { get; set; }
        int Left { get; set; }
        MaterialType Material { get; set; }
        bool[,] Shape { get; }
    }
}

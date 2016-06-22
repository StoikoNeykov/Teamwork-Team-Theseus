namespace GameLogic.Interfaces
{
    /// <summary>
    /// Playgrounds and other fields taht show on the screen
    /// </summary>
    public interface IField : IGameElement
    {
        IGameElement[,] Matrix { get; }
    }
}

namespace GameLogic.Interfaces
{
    /// <summary>
    /// Every game element - probably IGameElement[] will be passed to visualization module
    /// </summary>
    public interface IGameElement
    {
        int Width { get; }
        int Height { get; }
    }
}

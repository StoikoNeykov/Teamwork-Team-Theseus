namespace GameLogic.Interfaces
{
    /// <summary>
    /// Every game element - probably IGameElement[] will be passed to visualization module
    /// </summary>
    public interface IGameElement
    {
        short Width { get; }
        short Height { get; }
    }
}

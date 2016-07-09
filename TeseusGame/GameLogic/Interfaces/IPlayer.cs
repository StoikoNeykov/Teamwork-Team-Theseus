namespace GameLogic.Interfaces
{
    using Enumerations;

    public interface IPlayer : IBlock, IGameElement
    {
        Directions ViewDirection { get; set; }
    }
}

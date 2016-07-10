namespace GameLogic.Interfaces
{
    using Enumerations;

    public interface IPlayer : IBlock
    {
        Directions ViewDirection { get; set; }
    }
}

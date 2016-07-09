namespace GameLogic.Interfaces
{
    using Enumerations;

    public interface IEngine
    {
        void ExecuteCommand(IField playrground,IPlayer player, Commands command);
    }
}

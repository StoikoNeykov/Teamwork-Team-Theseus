namespace GameLogic.Interfaces
{
    using Enumerations;

    public interface IEngine
    {
        void ExecuteCommand(IField playrground, IField specialField, IPlayer player, string command);
    }
}

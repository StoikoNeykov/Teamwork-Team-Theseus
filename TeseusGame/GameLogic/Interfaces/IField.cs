namespace GameLogic.Interfaces
{
    public interface IField
    {
        int Width { get; }
        int Height { get; }
        int[,] Matrix { get; }
    }
}

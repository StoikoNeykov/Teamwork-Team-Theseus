namespace GameLogic.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Define factoy classes
    /// </summary>
    public interface ICreator
    {
       IList<IGameElement> Create(short count);
    }
}

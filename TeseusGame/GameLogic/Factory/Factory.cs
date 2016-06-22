namespace GameLogic.Factory
{
    using System.Collections.Generic;

    using Interfaces;

    public abstract class Factory : ICreator
    {
        public abstract IList<IGameElement> Create(short count = 1);
    }
}

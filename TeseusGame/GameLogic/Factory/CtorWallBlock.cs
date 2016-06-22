namespace GameLogic.Factory
{
    using System.Collections.Generic;

    using Interfaces;

    public class CtorWallBlock : Factory, ICreator
    {
        public override IList<IGameElement> Create(short count = 1)
        {
            var result = new List<IGameElement>();

            return result;
        }
    }
}

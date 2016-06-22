namespace GameLogic.Factory
{
    using System.Collections.Generic;

    using Extensions;
    using Interfaces;

    /// <summary>
    /// Generage collection of element for new level
    /// </summary>
    public class CtorLevel : Factory, ICreator
    {
        public override IList<IGameElement> Create(short count = 1)
        {
            var level = new List<IGameElement>();

            // TODO 
            var playg = new CtorPlayground();
            var collection = playg.Create();
            collection.ForEach(x => level.Add(x));
            
            return level;
        }
    }
}

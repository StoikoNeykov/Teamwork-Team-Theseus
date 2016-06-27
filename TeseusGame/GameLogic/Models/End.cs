namespace GameLogic.Models
{
    using Interfaces;

    /// <summary>
    /// Represent target location
    /// </summary>
    public class End : GameElement, IGameElement
    {
        public End() 
            : base(1, 1)
        {
        }

        // Note if top and left been set (for some reason) to be made ne abstract parent class 
        // for this and player class, to be changed LevelMaker too (where been set things like that)
    }
}

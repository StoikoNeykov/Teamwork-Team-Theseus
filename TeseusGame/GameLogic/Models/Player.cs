namespace GameLogic.Models
{
    using Interfaces;

    /// <summary>
    /// Represent player 
    /// </summary>
    public class Player : GameElement, IGameElement
    {
        public Player() 
            : base(1, 1)
        {
        }


        // Note if top and left been set (for some reason) to be made ne abstract parent class 
        // for this and player class, to be changed LevelMaker too (where been set things like that)
    }
}

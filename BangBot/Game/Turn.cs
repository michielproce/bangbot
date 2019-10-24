using BangBot.Game.Dice;

namespace BangBot.Game
{
    public class Turn
    {
        public int NrOfRolls { get; set; }
        public IFace[] CurrentFaces { get; set; }
        
        public Turn()
        {
            CurrentFaces = new IFace[5];
        }
    }
}
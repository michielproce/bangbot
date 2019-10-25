
namespace BangBot.Game
{
    public class Turn
    {
        public int NrOfRolls { get; set; }
        public Face[] CurrentFaces { get; set; }
        
        public Turn()
        {
            CurrentFaces = new Face[5];
        }
    }
}
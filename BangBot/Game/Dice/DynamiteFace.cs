using System.Linq;
using BangBot.Output;

namespace BangBot.Game.Dice
{
    public class DynamiteFace : IFace
    {
        public string Text => ":bangdynamite:";
        public bool CanReroll => false;
        public void ImmediateAction(IFace[] currentFaces)
        {
            int nrOfDynamiteFaces = currentFaces.Count(o => o is DynamiteFace);
            if (nrOfDynamiteFaces >= 3)
            {
                Out.main.Write($"{nrOfDynamiteFaces}x ${Text}: :boom:");
                
                Player player = BangGame.Current.CurrentPlayer;
                
                player.RemoveHealth();
                player.EndTurn();;
            }
        }
    }
}
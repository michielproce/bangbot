namespace BangBot.Game.Dice
{
    public class BeerFace : IFace
    {
        public string Text => ":bangbeer:";
        public bool CanReroll => true;
        public void ImmediateAction(IFace[] currentFaces)
        {
            
        }
    }
}
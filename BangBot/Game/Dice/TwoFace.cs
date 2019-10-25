namespace BangBot.Game.Dice
{
    public class TwoFace : IFace
    {
        public string Text => ":bang2:";
        public bool CanReroll => true;
        
        public void ImmediateAction(IFace[] currentFaces)
        {
        }
    }
}
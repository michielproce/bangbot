namespace BangBot.Game.Dice
{
    public class OneFace : IFace
    {
        public string Text => ":bang1:";
        public bool CanReroll => true;
        
        public void ImmediateAction(IFace[] currentFaces)
        {
        }
    }
}
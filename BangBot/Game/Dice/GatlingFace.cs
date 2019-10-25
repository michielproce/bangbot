namespace BangBot.Game.Dice
{
    public class GatlingFace : IFace
    {
        public string Text => ":bangkra:";
        public bool CanReroll => true;
        public void ImmediateAction(IFace[] currentFaces)
        {
        }
    }
}
namespace BangBot.Game.Dice
{
    public class DynamiteFace : IFace
    {
        public string Text => ":bangdynamite:";
        public bool CanReroll => false;
        public void ImmediateAction()
        {
        }
    }
}
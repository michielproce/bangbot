namespace BangBot.Game.Dice
{
    public class ArrowFace : IFace
    {
        public string Text => ":bangarrow:";
        public bool CanReroll => true;
        
        public void ImmediateAction(IFace[] currentFaces)
        {
            BangGame.Current.CurrentPlayer.AddArrow();
        }
    }
}
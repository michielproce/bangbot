namespace BangBot.Game.Dice
{
    public class ArrowFace : IFace
    {
        public string Text => ":bangarrow:";
        public bool CanReroll => true;
        
        public void ImmediateAction()
        {
            BangGame.Current.CurrentPlayer.RemoveArrow();
        }
    }
}
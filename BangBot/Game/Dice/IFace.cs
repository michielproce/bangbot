namespace BangBot.Game.Dice
{
    public interface IFace
    {
        string Text { get; }

        bool CanReroll { get; }

        void ImmediateAction();
    }
}
namespace BangBot.Game.Dice
{
    public class Die
    {
        public static IFace[] Faces => new IFace[] {
            new ArrowFace(),
            new DynamiteFace(),
            new OneFace(), 
            new TwoFace(), 
            new BeerFace(), 
            new GatlingFace(), 
        };
    }
}
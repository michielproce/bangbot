using System;

namespace BangBot.Game
{
    public static class FaceMethods
    {
        public static String GetText(this Face face)
        {
            switch (face)
            {
                case Face.Arrow:
                    return ":bangarrow:";
                case Face.Dynamite:
                    return ":bangdynamite:";
                case Face.One:
                    return ":bang1:";
                case Face.Two:
                    return ":bang2:";
                case Face.Beer:
                    return ":bangbeer:";
                case Face.Gatling:
                    return ":bangkra:";
                default:
                    throw new ArgumentOutOfRangeException(nameof(face), face, null);
            }
        }

        public static int GetPriority(this Face face)
        {
            switch (face)
            {
                case Face.Arrow:
                    return 0;
                case Face.Dynamite:
                    return 1;
                case Face.One:
                    return 2;
                case Face.Two:
                    return 3;
                case Face.Beer:
                    return 4;
                case Face.Gatling:
                    return 5;
                default:
                    throw new ArgumentOutOfRangeException(nameof(face), face, null);
            }
        }
    }
}
namespace BangBot.Util
{
    public static class MathUtils
    {
        public static int Wrap(int i, int min, int max)
        {
            if (i < 0)
            {
                return max - 1;
            }

            if (i >= max)
            {
                return min;
            }

            return i;
        }
    }
}
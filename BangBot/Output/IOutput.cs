namespace BangBot.Output
{
    public interface IOutput
    {
        void WriteLines(params string[] ss);
        void WritePrivateLines(string user, params string[] ss);
    }
}
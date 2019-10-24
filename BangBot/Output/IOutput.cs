namespace BangBot.Output
{
    public interface IOutput
    {
        void Write(params string[] messages);
        void WritePrivate(string user, params string[] messages);
    }
}
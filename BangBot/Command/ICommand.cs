namespace BangBot.Command
{
    public interface ICommand
    {
        string Trigger { get; }
        void Execute(string user, string parameters);
    }
}
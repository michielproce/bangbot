using BangBot.Game;

namespace BangBot.Command
{
    public interface ICommand
    {
        string Trigger { get; }
        bool OnlyForCurrentUser { get; }
        GameState? RequiredGameState { get; }
        void Execute(string user, string parameters);
    }
}
using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class AbortCommand : ICommand
    {
        public string Trigger => "abort";
        public bool OnlyForCurrentUser => false;
        public GameState? RequiredGameState => GameState.Lobby;
        
        public void Execute(string user, string parameters)
        {
            if (BangGame.Current?.StartUser == user)
            {
                Out.main.Write("Game creation has been aborted");
                BangGame.Current = null;
                StartGameCommand.Timer.Enabled = false;
            }
        }
    }
}
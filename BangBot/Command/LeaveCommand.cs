using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class LeaveCommand : ICommand
    {
        public string Trigger => "leave";
        public bool OnlyForCurrentUser => false;
        public GameState? RequiredGameState => GameState.Lobby;

        public void Execute(string user, string parameters)
        {
            if (BangGame.Current?.StartUser == user)
            {
                Out.main.Write("Starting user cannot leave. Abort game creation by typing 'abort'");
                return;
            }
            
            Out.main.Write($"{user} left the game");
            BangGame.Current.Leave(user);
        }
    }
}
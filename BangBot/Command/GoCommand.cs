using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class GoCommand : ICommand
    {
        public string Trigger => "go";
        public bool OnlyForCurrentUser => false;
        public GameState? RequiredGameState => GameState.Lobby;

        public void Execute(string user, string parameters)
        {
            if (BangGame.Current?.StartUser == user)
            {
                if (BangGame.Current.Users.Count < BangGame.MinPlayers)
                {
                    Out.main.Write($"Cannot proceed, {BangGame.MinPlayers} players required");
                    return;
                }
                
                Out.main.Write($"Starting game with {(string.Join(", ", BangGame.Current.Users))}");
                BangGame.Current.Go();
            }
        }
    }
}
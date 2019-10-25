using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class JoinGameCommand : ICommand
    {
        public string Trigger => "join";
        public bool OnlyForCurrentUser => false;
        public GameState? RequiredGameState => GameState.Lobby;

        public void Execute(string user, string parameters)
        {
            if (BangGame.Current.Users.Count >= BangGame.MaxPlayers)
            {
                Out.main.Write($"{user} cannot join. Game is full");
            }
            else
            {
                BangGame.Current.Join(user);
                Out.main.Write($"{user} has joined the game");
            }

            Out.main.Write(
                $"Current participants: {(string.Join(", ", BangGame.Current.Users))}",
                $"{BangGame.Current.StartUser} can start the game by typing 'go'"
            );
        }
    }
}
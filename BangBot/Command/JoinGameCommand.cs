using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class JoinGameCommand : ICommand
    {
        public string Trigger => "join";
        
        public void Execute(string user, string parameters)
        {
            if (BangGame.current?.State == GameState.Lobby)
            {
                if (BangGame.current.Users.Count >= BangGame.MaxPlayers)
                {
                    Out.main.Write($"{user} cannot join. Game is full");
                    
                }
                else
                {
                    BangGame.current.Join(user);
                    Out.main.Write($"{user} has joined the game");
                }

                Out.main.Write(
                    $"Current participants: {(string.Join(", ", BangGame.current.Users))}",
                    $"{BangGame.current.StartUser} can start the game by typing 'go'"
                );
            }
        }
    }
}
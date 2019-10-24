using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class JoinGameCommand : ICommand
    {
        public string Trigger => "join";
        
        public void Execute(string user, string parameters)
        {
            if (BangGame.current?.GameState == GameState.Lobby)
            {
                if (BangGame.current.Participants.Count >= BangGame.MaxPlayers)
                {
                    Out.main.WriteLines($"{user} cannot join. Game is full");
                    
                }
                else
                {
                    BangGame.current.Join(user);
                    Out.main.WriteLines($"{user} has joined the game");
                }

                Out.main.WriteLines(
                    $"Current participants: {(string.Join(", ", BangGame.current.Participants))}",
                    $"{BangGame.current.StartUser} can start the game by typing 'go'"
                );
            }
        }
    }
}
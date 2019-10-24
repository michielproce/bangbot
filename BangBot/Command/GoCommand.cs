using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class GoCommand : ICommand
    {
        public string Trigger => "go";
        
        public void Execute(string user, string parameters)
        {
            if (BangGame.current?.StartUser == user)
            {
                if (BangGame.current.Participants.Count < BangGame.MinPlayers)
                {
                    Out.main.WriteLines($"Cannot proceed, {BangGame.MinPlayers} players required");
                    return;
                }
                
                
                BangGame.current.Go();
                
                Out.main.WriteLines($"Starting game with {(string.Join(", ", BangGame.current.Participants))}");
            }
        }
    }
}
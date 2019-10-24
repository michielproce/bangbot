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
                if (BangGame.current.Users.Count < BangGame.MinPlayers)
                {
                    Out.main.Write($"Cannot proceed, {BangGame.MinPlayers} players required");
                    return;
                }
                
                Out.main.Write($"Starting game with {(string.Join(", ", BangGame.current.Users))}");
                BangGame.current.Go();
            }
        }
    }
}
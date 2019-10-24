using BangBot.Game;

namespace BangBot.Command
{
    public class ShowCommand : ICommand
    {
        public string Trigger => "show";
        
        public void Execute(string user, string parameters)
        {

            if (BangGame.current.State == GameState.Active)
            {
                Table.Draw();                
            }
        }
    }
}
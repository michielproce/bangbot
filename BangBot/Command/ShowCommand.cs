using BangBot.Game;

namespace BangBot.Command
{
    public class ShowCommand : ICommand
    {
        public string Trigger => "show";
        public bool OnlyForCurrentUser => false;
        public GameState? RequiredGameState => GameState.Active;

        public void Execute(string user, string parameters)
        {
            Table.Draw();
        }
    }
}
using BangBot.Game;

namespace BangBot.Command
{
    public class DoneCommand : ICommand
    {
        public string Trigger => "done";
        public bool OnlyForCurrentUser => true;
        public GameState? RequiredGameState => GameState.Active;
        
        public void Execute(string user, string parameters)
        {
            BangGame.Current.CurrentPlayer.TryEndTurn();
        }
    }
}
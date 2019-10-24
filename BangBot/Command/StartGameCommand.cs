using System.Timers;
using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class StartGameCommand : ICommand
    {
        private const int Timeout = 120_000;

        private Timer _timer;

        public string Trigger => "start";
        public bool OnlyForCurrentUser => false;
        public GameState? RequiredGameState => null;

        public void Execute(string user, string parameters)
        {
            if (BangGame.Current == null)
            {
                BangGame.Current = new BangGame(user);
                Out.main.Write(
                    $"{user} is starting a new game",
                    "To join type 'join'"
                );


                _timer = new Timer();
                _timer.Elapsed += OnTimerExpired;
                _timer.Interval = Timeout;
                _timer.Enabled = true;
            }
            else
            {
                Out.main.Write("Game already in progress");
            }
            
        }

        private void OnTimerExpired(object source, ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            
            if (BangGame.Current.State == GameState.Lobby)
            {
                Out.main.Write("Timed out. Destroying game");
                BangGame.Current = null;    
            }
        }
    }
}
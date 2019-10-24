using System.Timers;
using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class StartGameCommand : ICommand
    {
        private const int Timeout = 2_000;

        private Timer _timer;


        public string Trigger => "start";
        
        public void Execute(string user, string parameters)
        {
            if (BangGame.current == null)
            {
                BangGame.current = new BangGame(user);
                Out.main.WriteLines(
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
                Out.main.WriteLines("Game already in progress");
            }
            
        }

        private void OnTimerExpired(object source, ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            
            if (BangGame.current.GameState == GameState.Lobby)
            {
                Out.main.WriteLines("Timed out. Destroying game");
                BangGame.current = null;    
            }
        }
    }
}
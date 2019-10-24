using System.Collections.Generic;

namespace BangBot.Game
{
    public class BangGame
    {
        public const int MinPlayers = 5;
        public const int MaxPlayers = 8;
        
        public static BangGame current;
        private int _round;

        public string StartUser { get; }
        public GameState GameState { get; private set; }
        public List<string> Participants { get; }

        public BangGame(string startUser)
        {
            GameState = GameState.Lobby;
            
            StartUser = startUser;
            
            Participants = new List<string>();
            Participants.Add(startUser);
        }
        
        public void Join(string user)
        {
            Participants.Add(user);
        }

        public void Go()
        {
            GameState = GameState.Active;
        }
    }
}
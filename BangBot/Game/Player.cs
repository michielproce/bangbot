namespace BangBot.Game
{
    public class Player
    {
        public string user;
        public Role Role { get; }

        public Player(string user, Role role)
        {
            this.user = user;
            Role = role;
        }
    }
    
}
using BangBot.Output;

namespace BangBot.Game
{
    public class Player
    {
        public string User { get; }
        
        public Role Role { get; }
        public bool RoleRevealed { get; private set; }

        public int Health { get; private set; }
        public int Arrows { get; private set; }
        
        public Turn Turn { get; private set; }

        public Player(string user, Role role)
        {
            User = user;
            Role = role;

            Health = 10;
            Arrows = 0;

            if (role == Role.Sheriff)
            {
                RoleRevealed = true;
            }
        }

        public void StartTurn()
        {
            Turn = new Turn(); 
            Out.main.Write($"{User}'s turn. Available commands: 'roll'");
            
        }

        public void EndTurn()
        {
            Out.main.Write($"Ending {User}'s turn");            
            
            Turn = null;
        }

        public void RemoveHealth()
        {
            Out.main.Write($"{User} lost health");
            Health--;
        }

        public void AddArrow()
        {
            Out.main.Write($"Arrow for {User}");
            Arrows++;
        }
    }
}
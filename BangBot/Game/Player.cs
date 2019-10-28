using BangBot.Output;

namespace BangBot.Game
{
    public class Player
    {
        public string User { get; }
        public Role Role { get; }
        public bool RoleRevealed { get; }

        public int Health { get; private set; }
        public int Arrows { get; private set; }
        
        public Turn Turn { get; private set; }
        
        public int Index { get; set; }

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
            Turn = new Turn(User);
            Out.main.Write($"{User}'s turn. Available commands: 'roll'");
        }

        public void TryEndTurn()
        {
            if (Turn.TryEnd())
            {
                Out.main.Write($"Ending {User}'s turn");
                Turn = null;
                BangGame.Current.NextPlayer();                
            }
        }

        public void RemoveHealth()
        {
            Out.main.Write($"{User} lost health");
            Health--;
        }

        public void AddArrows(int arrowCount)
        {
            Out.main.Write($"{arrowCount}x arrow for {User}");
            Arrows += arrowCount;
        }

        public void AddHealth()
        {
            Out.main.Write($"{User} gains health");
            Health++;
        }
    }
}
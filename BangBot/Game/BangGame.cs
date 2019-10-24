using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BangBot.Output;

namespace BangBot.Game
{
    public class BangGame
    {
        public const int MinPlayers = 4;
        public const int MaxPlayers = 7;

        public static BangGame current;
        private int _round;

        public string StartUser { get; }
        public GameState GameState { get; private set; }
        public List<string> Users { get; }


        public Player[] Players { get; private set; }
        public int CurrentPlayerIndex { get; private set; }
        public Player CurrentPlayer => Players[CurrentPlayerIndex];

        public BangGame(string startUser)
        {
            GameState = GameState.Lobby;
            
            StartUser = startUser;
            
            Users = new List<string>();
            Users.Add(startUser);
        }
        
        public void Join(string user)
        {
            Users.Add(user);
        }

        public void Go()
        {
            GameState = GameState.Active;
            List<Role> roles = CreateRoles();
            
            Players = new Player[Users.Count];
            
            for (int i = 0; i < Users.Count; i++)
            {
                string user = Users[i];
                Role role = roles[i];
                Players[i] = new Player(user, role);
                Out.main.WritePrivate(user, $"You are: {role}");
            }
            
            
            Players = Players.OrderBy(a => Program.Random.Next()).ToArray();

            Table.Draw();
            
            CurrentPlayer.StartTurn();
        }


        private List<Role> CreateRoles()
        {
            List<Role> roles = new List<Role>();

            switch (Users.Count)
            {
                case 4:
                    roles.AddRange(new[] {Role.Sheriff, Role.Renegade, Role.Outlaw, Role.Outlaw});
                    break;
                case 5:
                    roles.AddRange(new[] {Role.Sheriff, Role.Renegade, Role.Outlaw, Role.Outlaw, Role.Deputy});
                    break;
                case 6:
                    roles.AddRange(new[] {Role.Sheriff, Role.Renegade, Role.Outlaw, Role.Outlaw, Role.Outlaw, Role.Deputy});
                    break;
                case 7:
                    roles.AddRange(new[] {Role.Sheriff, Role.Renegade, Role.Outlaw, Role.Outlaw, Role.Outlaw, Role.Deputy, Role.Deputy});
                    break;
                case 8:
                    roles.AddRange(new[] {Role.Sheriff, Role.Renegade, Role.Outlaw, Role.Outlaw, Role.Deputy});
                    break;
            }
            
            if (roles.Count != Users.Count)
            {
                throw new ThreadStateException("Role count does not match participant count");
            }

            return roles.OrderBy(a => Program.Random.Next()).ToList();
        }
    }
}
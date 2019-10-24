using System.Collections.Generic;
using BangBot.Output;

namespace BangBot.Game
{
    public class Table
    {
        public static void Draw()
        {
            Player[] players = BangGame.Current.Players;
            
            List<string> lines = new List<string>(players.Length);
            
            for (int i = 0; i < players.Length; i++)
            {
                Player player = players[i];

                string role = player.RoleRevealed ? player.Role.ToString() : "Unknown";
                string line = $"{i}. {player.User} (Role: {role}, Health: {player.Health}, Arrows: {player.Arrows})";


                if (i == BangGame.Current.CurrentPlayerIndex)
                {
                    line += " <-- (current)";
                }
                
                lines.Add(line);
            }
            
            Out.main.Write(lines.ToArray());
        }
    }
}
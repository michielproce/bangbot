using System;
using System.Linq;
using System.Text.RegularExpressions;
using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class RollCommand : ICommand
    {
        public string Trigger => "roll";
        public bool OnlyForCurrentUser => true;
        public GameState? RequiredGameState => GameState.Active;

        public void Execute(string user, string parameters)
        {
            Player player = BangGame.Current.CurrentPlayer;
        
            Face[] currentFaces = player.Turn.CurrentFaces;

            if (player.Turn.NrOfRolls >= 3) 
            {
                Out.main.Write("Max number of rolls reached");
                return;
            }
            
            int[] requestedDice;
            if (player.Turn.NrOfRolls == 0)
            {
                // First roll, always roll all dice
                requestedDice = new[] {0, 1, 2, 3, 4};
            }
            else 
            {
                // Second/third/fourth roll, roll dice specified by user
                string parameterValue = Regex.Match(parameters, @"\d+").Value;
                requestedDice = parameterValue.ToCharArray().Select(o => Int32.Parse(Char.ToString(o)) - 1).Distinct().ToArray();
                
                foreach (int requestedDie in requestedDice)
                {
                    if (requestedDie < 0 || requestedDie > 4)
                    {
                        return;
                    }
                }
                
                foreach (int requestedDie in requestedDice)
                {
                    if (currentFaces[requestedDie] == Face.Dynamite)
                    {
                        Out.main.Write("Cannot re-roll dynamite");
                        return;
                    }
                }
            }

            Roll(requestedDice, currentFaces);
            
            string facesTexts = string.Join("", currentFaces.Select(o => o.GetText()));
            Out.main.Write($"Roll #{player.Turn.NrOfRolls + 1}: {facesTexts}");
            player.Turn.NrOfRolls++;
            
            int dynamiteCount = currentFaces.Count(o => o == Face.Dynamite);
            if (dynamiteCount >= 3)
            {
                Out.main.Write($"{dynamiteCount}x {Face.Dynamite.GetText()}. BOOM!");
                player.RemoveHealth();
                player.EndTurn();
            }
            
            Out.main.Write("If you are satisfied with you roll, type 'done'");
        }

        private void Roll(int[] requestedRolls, Face[] currentFaces)
        {
            Face[] faces = (Face[]) Enum.GetValues(typeof(Face));
            
            foreach (int requestedRoll in requestedRolls)
            {
                currentFaces[requestedRoll] = faces[Program.Random.Next(0, faces.Length)];
                currentFaces[requestedRoll] = Face.Dynamite;
            }
            
        }
    }
}
using System;
using System.Linq;
using System.Text.RegularExpressions;
using BangBot.Game;
using BangBot.Output;

namespace BangBot.Command
{
    public class RollCommand : ICommand
    {
        private static readonly Face[] _availableFaces = (Face[]) Enum.GetValues(typeof(Face));
        
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

            // Roll!
            Face[] newFaces = new Face[requestedDice.Length];
            for (int i = 0; i < requestedDice.Length; i++)
            {
                Face rolledFace = _availableFaces[Program.Random.Next(0, _availableFaces.Length)];
                newFaces[i] = rolledFace;
                
                int requestedDie = requestedDice[i];
                currentFaces[requestedDie] = rolledFace;
            }
            
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

            int arrowCount = newFaces.Count(o => o == Face.Arrow);
            if (arrowCount > 0)
            {
                player.AddArrows(arrowCount);
            }

            Out.main.Write("If you are satisfied with you roll, type 'done'");
        }
    }
}
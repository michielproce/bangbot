using System;
using System.Linq;
using System.Text.RegularExpressions;
using BangBot.Game;
using BangBot.Game.Dice;
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
        
            IFace[] currentFaces = player.Turn.CurrentFaces;

            if (player.Turn.NrOfRolls >= 3) 
            {
                Out.main.Write("Max number of rolls reached");
                return;
            }

            if (player.Turn.NrOfRolls == 0)
            {
                Roll(new[] {0, 1, 2, 3, 4}, currentFaces);
            }
            else
            {
                string parameterValue = Regex.Match(parameters, @"\d+").Value;
                int[] diceToRoll = parameterValue.ToCharArray().Select(o => Int32.Parse(Char.ToString(o)) - 1).Distinct().ToArray();
                
                foreach (int i in diceToRoll)
                {
                    if (i < 0 || i > 4)
                    {
                        return;
                    }
                }
                
                Roll(diceToRoll, currentFaces);
            }

            string facesTexts = string.Join("", currentFaces.Select(o => o.Text));
            Out.main.Write($"Roll #{player.Turn.NrOfRolls + 1}: {facesTexts}");
            player.Turn.NrOfRolls++;
        }

        private void Roll(int[] dice, IFace[] currentFaces)
        {
            foreach (int die in dice)
            {
                currentFaces[die] = Die.Faces[Program.Random.Next(0, Die.Faces.Length)];
                currentFaces[die].ImmediateAction();
            }
        }
    }
}
using System;
using BangBot.Game;

namespace BangBot.Command
{
    public class TargetCommand : ICommand
    {
        public string Trigger => "target";
        public bool OnlyForCurrentUser => true;
        public GameState? RequiredGameState => GameState.Active;

        public void Execute(string user, string parameters)
        {
            Turn turn = BangGame.Current.CurrentPlayer.Turn;
            Face? currentUnresolvedFace = turn.CurrentUnresolvedFace;
            if (!currentUnresolvedFace.HasValue)
            {
                return;
            }

            if (!int.TryParse(parameters.Trim(), out int targetIndex))
            {
                return;
            }
            
            switch (currentUnresolvedFace.Value)
            {
                case Face.One:
                    if (targetIndex != turn.GetNeighbour(-1).Index && targetIndex != turn.GetNeighbour(1).Index)
                    {
                        return;
                    }
                        
                    BangGame.Current.Players[targetIndex].RemoveHealth();
                    break;
                case Face.Two:
                    if (targetIndex != turn.GetNeighbour(-2).Index && targetIndex != turn.GetNeighbour(2).Index)
                    {
                        return;
                    }
                        
                    BangGame.Current.Players[targetIndex].RemoveHealth();
                    break;
                case Face.Beer:
                {
                    if (targetIndex < 0 || targetIndex >= BangGame.Current.Players.Length)
                    {
                        return;
                    }
                        
                    BangGame.Current.Players[targetIndex].AddHealth();
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }

            turn.ResolveCurrentFace();
        }
    }
}
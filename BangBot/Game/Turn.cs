using System;
using System.Collections.Generic;
using System.Linq;
using BangBot.Output;
using BangBot.Util;

namespace BangBot.Game
{
    public class Turn
    {
        private List<Face> _unresolvedFaces;
        private String _user;

        public int NrOfRolls { get; set; }
        public Face[] CurrentFaces { get; }

        public Face? CurrentUnresolvedFace
        {
            get
            {
                if (_unresolvedFaces?.Count == 0)
                {
                    return null;
                }

                return _unresolvedFaces[0];
            }
        }

        public Turn(string user)
        {
            CurrentFaces = new Face[5];
            _user = user;
        }

        public bool TryEnd()
        {
            if (_unresolvedFaces == null)
            {
                _unresolvedFaces = CurrentFaces
                    .Where(o => o == Face.One || o == Face.Two || o == Face.Beer)
                    .OrderBy(o => o.GetPriority())
                    .ToList();
            }

            if (_unresolvedFaces.Count == 0)
            {
                return true;
            }

            Face unresolvedFace = _unresolvedFaces[0];

            Out.main.Write($"Current die: {unresolvedFace.GetText()}");


            Player[] targets = new Player[0];
            switch (unresolvedFace)
            {
                case Face.One:
                    targets =  new Player[] {
                        GetNeighbour(-1),
                        GetNeighbour(1)
                    };
                    break;
                case Face.Two:
                    targets =  new Player[] {
                        GetNeighbour(-2),
                        GetNeighbour(2)
                    };
                    break;
                case Face.Beer:
                    targets = BangGame.Current.Players;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            
            foreach (Player option in targets)
            {
                Out.main.Write($"Type 'target {option.Index}' to target {option.User}");
            }


            return false;
        }
        
        
        public void ResolveCurrentFace()
        {

            if (_unresolvedFaces?.Count() == 0)
            {
                return;
            }
            
            _unresolvedFaces.RemoveAt(0);

            BangGame.Current.CurrentPlayer.TryEndTurn();
        }

        public Player GetNeighbour(int offset)
        {
            Player[] currentPlayers = BangGame.Current.Players;
            return currentPlayers[MathUtils.Wrap(BangGame.Current.CurrentPlayerIndex + offset, 0, currentPlayers.Length)];
        }

    }
}
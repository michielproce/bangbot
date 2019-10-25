
using System;
using System.Collections.Generic;
using System.Linq;

namespace BangBot.Game
{
    public class Turn
    {
        public int NrOfRolls { get; set; }
        public Face[] CurrentFaces { get; }

        private List<Face> _unresolvedFaces;
        
        private String _user;

        public Turn(string user)
        {
            CurrentFaces = new Face[5];
            _user = user;
        }

        public bool TryEnd()
        {
            _unresolvedFaces = CurrentFaces
                .Where(o => o == Face.One || o == Face.Two || o == Face.Beer)
                .OrderBy(o=>o.GetPriority())
                .ToList();
            
            // TODO: Resolve faces
            
            return _unresolvedFaces.Count == 0;
        }
    }
}
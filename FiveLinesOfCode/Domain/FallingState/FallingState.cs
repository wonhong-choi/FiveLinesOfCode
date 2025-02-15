using FiveLinesOfCode.Domain.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.FallingState
{
    internal class FallingState : IFallingState
    {
        public bool IsFalling()
        {
            return true;
        }

        public void MoveHorizontal(ITile tile, int dx)
        {
            
        }
    }
}

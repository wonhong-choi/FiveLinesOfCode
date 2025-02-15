using FiveLinesOfCode.Domain.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.FallingState
{
    internal interface IFallingState
    {
        bool IsFalling();

        void MoveHorizontal(ITile tile, int dx);
    }
}

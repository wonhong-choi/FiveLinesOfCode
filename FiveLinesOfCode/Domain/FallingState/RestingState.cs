using FiveLinesOfCode.Domain.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.FallingState
{
    internal class RestingState : IFallingState
    {
        public bool IsFalling()
        {
            return false;
        }

        public void MoveHorizontal(ITile tile, int dx)
        {
            if (_map[_playerY][_playerX + dx + dx].IsAIR() && !_map[_playerY + 1][_playerX + dx].IsAIR())
            {
                _map[_playerY][_playerX + dx + dx] = this;
                MoveToTile(_playerX + dx, _playerY);
            }
        }
    }
}

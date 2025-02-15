using FiveLinesOfCode.Domain.FallingState;
using FiveLinesOfCode.Domain.Tile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.FallStrategy
{
    internal class FallStrategy
    {
        private IFallingState _fallingState;

        public FallStrategy(IFallingState fallingState)
        {
            _fallingState = fallingState;
        }

        public IFallingState GetFallingState()
        {
            return _fallingState;
        }

        internal void Update(ITile tile, int x, int y)
        {
            _fallingState = _map[y + 1][x].IsAIR() ? new FallingState.FallingState() : new RestingState();
            Drop(tile, x, y);
        }

        private void Drop(ITile tile, int x, int y)
        {
            if (_fallingState.IsFalling())
            {
                _map[y + 1][x] = tile;
                _map[y][x] = new AirTile();
            }
        }
    }
}
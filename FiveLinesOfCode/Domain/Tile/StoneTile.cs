using FiveLinesOfCode.Domain.FallingState;
using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    internal class StoneTile : ITile
    {
        private IFallingState _fallingState;

        public StoneTile(IFallingState fallingState)
        {
            _fallingState = fallingState;
        }

        public void Draw(GraphicContext g, int y, int x)
        {
            g.FillStyle = "#0000cc";
            g.FillRect(x * TileConfig.TILE_SIZE, y * TileConfig.TILE_SIZE, TileConfig.TILE_SIZE, TileConfig.TILE_SIZE);
        }

        public void Drop()
        {
            _fallingState = new FallingState.FallingState();
        }

        public bool IsAIR()
        {
            return false;
        }

        public bool IsFalling()
        {
            return _fallingState.IsFalling();
        }

        public bool IsLOCK1()
        {
            return false;
        }

        public bool IsLOCK2()
        {
            return false;
        }

        public void MoveHorizontal(int dx)
        {
            _fallingState.MoveHorizontal(this, dx);
        }

        public void MoveVertical(int dy)
        {
        }

        public void Rest()
        {
            _fallingState = new RestingState();
        }

        public bool CanFall()
        {
            return true;
        }
    }
}

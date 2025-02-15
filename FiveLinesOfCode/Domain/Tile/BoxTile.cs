using FiveLinesOfCode.Domain.FallingState;
using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    internal class BoxTile : ITile
    {
        private IFallingState _fallingState;

        public BoxTile(IFallingState fallingState)
        {
            _fallingState = fallingState;
        }

        public void Draw(GraphicContext g, int y, int x)
        {
            g.FillStyle = "#8b4513";
            g.FillRect(x * TileConfig.TILE_SIZE, y * TileConfig.TILE_SIZE, TileConfig.TILE_SIZE, TileConfig.TILE_SIZE);
        }


        public bool IsAIR()
        {
            return false;
        }

        public bool IsBOX()
        {
            return true;
        }

        public bool IsBoxy()
        {
            return true;
        }

        public bool IsEdible()
        {
            return false;
        }

        public bool IsFALLING_BOX()
        {
            return _fallingState.IsFalling();
        }

        public bool IsFALLING_STONE()
        {
            return false;
        }

        public bool IsFLUX()
        {
            return false;
        }

        public bool IsKEY1()
        {
            return false;
        }

        public bool IsKEY2()
        {
            return false;
        }

        public bool IsLOCK1()
        {
            return false;
        }

        public bool IsLOCK2()
        {
            return false;
        }

        public bool IsPLAYER()
        {
            return false;
        }

        public bool IsPushable()
        {
            return true;
        }

        public bool IsSTONE()
        {
            return false;
        }

        public bool IsStony()
        {
            return false;
        }

        public bool IsUNBREAKABLE()
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
    }
}

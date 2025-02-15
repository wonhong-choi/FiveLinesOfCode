using FiveLinesOfCode.Domain.FallingState;
using FiveLinesOfCode.Domain.FallStrategy;
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
        private FallStrategy.FallStrategy _fallStrategy;

        public StoneTile(IFallingState fallingState)
        {
            _fallStrategy = new FallStrategy.FallStrategy(fallingState);
        }

        public void Draw(GraphicContext g, int y, int x)
        {
            g.FillStyle = "#0000cc";
            g.FillRect(x * TileConfig.TILE_SIZE, y * TileConfig.TILE_SIZE, TileConfig.TILE_SIZE, TileConfig.TILE_SIZE);
        }

        public bool IsAIR()
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

        public void MoveHorizontal(int dx)
        {
            _fallStrategy.GetFallingState().MoveHorizontal(this, dx);
        }

        public void MoveVertical(int dy)
        {
        }

        public bool CanFall()
        {
            return true;
        }

        public void Update(int x, int y)
        {
            _fallStrategy.Update(this, x, y);
        }
    }
}

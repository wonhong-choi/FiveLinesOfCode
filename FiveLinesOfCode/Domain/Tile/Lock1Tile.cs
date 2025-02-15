using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    internal class Lock1Tile : ITile
    {
        public void Draw(GraphicContext g, int y, int x)
        {
            g.FillStyle = "#ffcc00";
            g.FillRect(x * TileConfig.TILE_SIZE, y * TileConfig.TILE_SIZE, TileConfig.TILE_SIZE, TileConfig.TILE_SIZE);

        }

        public void Drop()
        {
        }

        public bool IsAIR()
        {
            return false;
        }

        public bool IsFalling()
        {
            return false;
        }

        public bool IsLOCK1()
        {
            return true;
        }

        public bool IsLOCK2()
        {
            return false;
        }

        public void MoveHorizontal(int dx)
        {
        }

        public void MoveVertical(int dy)
        {
        }

        public void Rest()
        {
        }

        public bool CanFall()
        {
            return false;
        }
    }
}

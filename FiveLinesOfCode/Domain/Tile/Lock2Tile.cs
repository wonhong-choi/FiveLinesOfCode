using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    internal class Lock2Tile : ITile
    {
        public void Draw(GraphicContext g, int y, int x)
        {
            g.FillStyle = "#00ccff";
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
            return true;
        }

        public void MoveHorizontal(int dx)
        {
        }

        public void MoveVertical(int dy)
        {
        }


        public bool CanFall()
        {
            return false;
        }

        public void Update(int x, int y)
        {
        }
    }
}

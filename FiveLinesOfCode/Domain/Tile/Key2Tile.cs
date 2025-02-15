using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    internal class Key2Tile : ITile
    {
        public void Draw(GraphicContext g, int y, int x)
        {
            g.FillStyle = "#00ccff";
            g.FillRect(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
        }

        public bool IsAIR()
        {
            return false;
        }

        public bool IsBOX()
        {
            return false;
        }

        public bool IsEdible()
        {
            return false;
        }

        public bool IsFALLING_BOX()
        {
            return false;
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
            return true;
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
            return false;
        }

        public bool IsSTONE()
        {
            return false;
        }

        public bool IsUNBREAKABLE()
        {
            return false;
        }

        public void MoveHorizontal(int dx)
        {
            RemoveLock2();
            MoveToTile(_playerX + dx, _playerY);
        }

        public void MoveVertical(int dy)
        {
            RemoveLock2();
            MoveToTile(_playerX, _playerY + dy);
        }
    }
}

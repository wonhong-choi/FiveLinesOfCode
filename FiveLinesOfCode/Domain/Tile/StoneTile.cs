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
        public void Draw(GraphicContext g, int y, int x)
        {
            g.FillStyle = "#0000cc";
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
            return true;
        }

        public bool IsUNBREAKABLE()
        {
            return false;
        }

        public void MoveHorizontal(int dx)
        {
            if (_map[_playerY][_playerX + dx + dx].IsAIR() && !_map[_playerY + 1][_playerX + dx].IsAIR())
            {
                _map[_playerY][_playerX + dx + dx] = this;
                MoveToTile(_playerX + dx, _playerY);
            }
        }

        public void MoveVertical(int dy)
        {
        }
    }
}

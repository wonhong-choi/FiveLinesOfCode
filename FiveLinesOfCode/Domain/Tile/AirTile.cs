using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    internal class AirTile : ITile
    {
        public void Draw(GraphicContext g, int y, int x)
        {
        }

        public bool IsAIR()
        {
            return true;
        }

        public bool IsBOX()
        {
            return false;
        }

        public bool IsBoxy()
        {
            return false;
        }

        public bool IsEdible()
        {
            return true;
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
            return false;
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
            MoveToTile(_playerX + dx, _playerY);
        }

        public void MoveVertical(int dy)
        {
            MoveToTile(_playerX, _playerY + dy);
        }


    }
}

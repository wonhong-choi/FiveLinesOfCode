using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    internal class FluxTile : ITile
    {
        public bool IsAIR()
        {
            return false;
        }

        public bool IsBOX()
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
            return true;
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

        public bool IsSTONE()
        {
            return false;
        }

        public bool IsUNBREAKABLE()
        {
            return false;
        }
    }
}

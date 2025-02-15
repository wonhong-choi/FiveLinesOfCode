using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    public interface ITile
    {
        bool IsAIR();
        bool IsFLUX();
        bool IsUNBREAKABLE();
        bool IsPLAYER();
        bool IsSTONE();
        bool IsFALLING_STONE();
        bool IsBOX();
        bool IsFALLING_BOX();
        bool IsKEY1();
        bool IsLOCK1();
        bool IsKEY2();
        bool IsLOCK2();

        bool IsEdible();

        bool IsPushable();

        void Draw(GraphicContext g, int y, int x);

        void MoveHorizontal(int dx);
        
        void MoveVertical(int dy)
    }
}

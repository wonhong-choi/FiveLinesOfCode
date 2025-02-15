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
        bool IsLOCK1();
        bool IsLOCK2();
        void Draw(GraphicContext g, int y, int x);
        void MoveHorizontal(int dx);
        void MoveVertical(int dy);
        void Drop();
        void Rest();
        bool CanFall();
        void Update(int x, int y);
    }
}

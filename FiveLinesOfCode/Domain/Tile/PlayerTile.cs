using FiveLinesOfCode.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Tile
{
    internal class PlayerTile : ITile
    {
        public void Draw(GraphicContext g, int y, int x)
        {
        }

        public void Drop()
        {
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

        public void Update(int x, int y)
        {
        }
    }
}

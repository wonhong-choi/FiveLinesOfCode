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
            MoveToTile(_playerX + dx, _playerY);
        }

        public void MoveVertical(int dy)
        {
            MoveToTile(_playerX, _playerY + dy);
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

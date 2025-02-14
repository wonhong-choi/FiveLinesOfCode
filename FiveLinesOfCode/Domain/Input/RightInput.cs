using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Input
{
    public class RightInput : IInput
    {
        public void Handle()
        {
            MoveHorizontal(1);
        }

        public bool IsDown()
        {
            return false;
        }

        public bool IsLeft()
        {
            return false;
        }

        public bool IsRight()
        {
            return true;
        }

        public bool IsUp()
        {
            return false;
        }
    }
}

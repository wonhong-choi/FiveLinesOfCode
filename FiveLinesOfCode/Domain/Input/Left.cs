using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Input
{
    public class Left : IInput
    {
        public void Handle()
        {
            MoveHorizontal(-1);
        }

        public bool IsDown()
        {
            return false;
        }

        public bool IsLeft()
        {
            return true;
        }

        public bool IsRight()
        {
            return false;
        }

        public bool IsUp()
        {
            return false;
        }
    }
}

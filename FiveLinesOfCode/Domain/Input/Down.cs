using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Input
{
    public class Down : IInput
    {
        public bool IsDown()
        {
            return true;
        }

        public bool IsLeft()
        {
            return false;
        }

        public bool IsRight()
        {
            return false;
        }

        public bool IsUp()
        {
            return false;
        }

        public void Handle()
        {
            MoveVertical(1);
        }
    }
}

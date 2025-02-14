using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Input
{
    public class Up : IInput
    {

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
            return false;
        }

        public bool IsUp()
        {
            return true;
        }

        public void Handle()
        {
            MoveVertical(-1);
        }
    }
}

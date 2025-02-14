using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiveLinesOfCode.Domain.Input
{
    public interface IInput
    {
        bool IsRight();
        bool IsLeft();
        bool IsUp();
        bool IsDown();
        void Handle();
    }
}

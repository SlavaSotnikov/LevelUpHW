using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum_Flags_
{
    [Flags]
    enum DayOfWeek : byte
    {
        Emptyday      = 0x00,
        Monday        = 0x01,
        Tuesday       = 0x02,
        Wednesday     = 0x04,
        Thursday      = 0x08,
        Friday        = 0x10,
        Saturday      = 0x20,
        Sunday        = 0x40
    }
}

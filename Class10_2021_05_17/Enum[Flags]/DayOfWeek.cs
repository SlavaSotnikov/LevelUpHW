using System;

namespace Enum_Flags_
{
    [Flags]
    enum DayOfWeek : ushort
    {
        Emptyday      = 0x000,

        Monday_Gym    = 0x0001,
        Tuesday_Gym   = 0x0002,
        Wednesday_Gym = 0x0004,
        Thursday_Gym  = 0x0008,
        Friday_Gym    = 0x0010,
        Saturday_Gym  = 0x0020,
        Sunday_Gym    = 0x0040,

        Monday_Jogging    = 0x0100,
        Tuesday_Jogging   = 0x0200,
        Wednesday_Jogging = 0x0400,
        Thursday_Jogging  = 0x0800,
        Friday_Jogging    = 0x1000,
        Saturday_Jogging  = 0x2000,
        Sunday_Jogging    = 0x4000
    }
}

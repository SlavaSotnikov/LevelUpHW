using System;

namespace MoveShip
{
    [Flags]
    enum Actions : byte
    {
        NoDirection = 0x00,
        LeftMove    = 0x01,
        RightMove   = 0x02, 
        UpMove      = 0x04,
        DownMove    = 0x08,
        Shooting    = 0x10,
        Exit        = 0x20
    }
}

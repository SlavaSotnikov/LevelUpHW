using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Display
    {
        public static void SetUserShipData(GameField source)
        {
            int i = 0;

            for (; i < source.AmountOfObj; i++)
            {
                if (source[i] is UserShip)
                {
                    break;
                }
            }

            UserShip one = (UserShip)source[i];

            if (one.HitPoints != one.OldHitPoints)
            {
                UI.ShowDisplay(one.HitPoints, source);

                one.OldHitPoints = one.HitPoints;
            }
        }
    }
}

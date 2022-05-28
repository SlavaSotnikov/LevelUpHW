using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_20_LowCoupling_HighCohesion
{
    internal class TimeData
    {
        private List<int> _time;

        public TimeData()
        {
            _time = new List<int>();
        }

        public void AddTime(int time)
        {
            if (time < 0)
            {
                return;
            }

            _time.Add(time);
        }
    }
}

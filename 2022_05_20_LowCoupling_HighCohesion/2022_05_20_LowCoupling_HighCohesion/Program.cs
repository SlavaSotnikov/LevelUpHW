using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_20_LowCoupling_HighCohesion
{
    internal class Program
    {
        static void Main()
        {
            TimeData td = new TimeData();

            var temperature = new TemperatureData();

            var result = temperature.GetAverage();

        }
    }
}

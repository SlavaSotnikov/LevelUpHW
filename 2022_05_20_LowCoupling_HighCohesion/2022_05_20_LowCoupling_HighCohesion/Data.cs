using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_20_LowCoupling_HighCohesion
{
    internal class Data
    {
        private List<int> _time;
        private List<int> _temperature;

        public Data()
        {
            _time = new List<int>();
            _temperature = new List<int>();
        }

        public void AddTime(int time)
        {
            if (time < 0)
            {
                return;
            }

            _time.Add(time);
        }

        public void AddTemperature(int temperature)
        {
            _temperature.Add(temperature);
        }

        public double GetTemperatureAverage()
        {
            if (_temperature == null || _temperature.Count <= 0)
            {
                return default;
            }

            return _temperature.Average(x => x);
        }
    }
}

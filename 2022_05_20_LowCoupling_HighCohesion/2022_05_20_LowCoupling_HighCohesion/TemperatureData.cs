using System.Collections.Generic;
using System.Linq;

namespace _2022_05_20_LowCoupling_HighCohesion
{
    internal class TemperatureData
    {
        private List<int> _temperature;

        public TemperatureData()
        {
            _temperature = new List<int>();
        }

        public void AddTemperature(int temperature)
        {
            _temperature.Add(temperature);
        }

        public double GetAverage()
        {
            if (_temperature == null || _temperature.Count <= 0)
            {
                return 0;
            }

            return _temperature.Average(x => x);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2022_05_13_Builder
{
    internal class Program
    {
        static void Main()
        {
            Plant plant = new Plant();

            ICreator creator = new LightShipCreator();

            Ship ship = plant.CreateShip(creator);

            Console.WriteLine(ship.ToString());

            Console.ReadKey();
        }
    }
}

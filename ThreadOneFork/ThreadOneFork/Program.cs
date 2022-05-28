using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadOneFork
{
    internal class Program
    {
        static void Main()
        {
            Fork fork = new Fork("Fork");

            Thread one = null;
            Thread two = null;

            using (var logger = new Logger())
            {
                var kant = new Kant(fork, "Kant", logger);
                var aristotle = new Aristotle(fork, "Aristotle", logger);

                one = new Thread(aristotle.HaveDinner);
                two = new Thread(kant.HaveDinner);

                one.Start();
                two.Start();


                Console.WriteLine("Press any key...");
                Console.ReadKey();
            }
        }
    }
}

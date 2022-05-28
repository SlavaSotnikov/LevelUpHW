using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace _2022_05_02_DinnerPhilosopher
{
    internal class Program
    {
        private static readonly Random _rnd = new Random();

        static void Main()
        {
            using (var logger = new Logger())
            {
                List<Thread> threads = new List<Thread>();

                var philosophers = _rnd.NextPhilosophers(logger).ToList();
                var forks = _rnd.NextForks();

                SetTheTable(philosophers, forks);

                foreach (var philosopher in philosophers)
                {
                    var thread = new Thread(philosopher.HaveDinner);
                    thread.Name = philosopher.ToString();
                    threads.Add(thread);
                }

                for (int i = 0; i < philosophers.Count; i++)
                {
                    threads[i].IsBackground = true;
                    threads[i].Start();
                }

                for (int i = 0; i < philosophers.Count; i++)
                {
                    threads[i].Join();
                }
            }
        }

        public static void SetTheTable(IEnumerable<Philosopher> one, IEnumerable<Fork> two)
        {
            var philosophers = one.ToList();
            var forks = two.ToList();

            int i;
            for (i = 0; i < philosophers.Count; i++)
            {
                philosophers[i].RightFork = forks[i];

                if (i + 1 >= philosophers.Count)
                {
                    philosophers[i].LeftFork = forks[0];
                    break;
                }

                philosophers[i].LeftFork = forks[i + 1];
            }
        }
    }
}

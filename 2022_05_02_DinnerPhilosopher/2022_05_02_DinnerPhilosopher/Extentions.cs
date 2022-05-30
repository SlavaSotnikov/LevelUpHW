using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _2022_05_02_DinnerPhilosopher
{
    internal static class Extentions
    {
        private static Philosophers[] _philosophers = 
        {
            Philosophers.Kant,
            Philosophers.Aristotle,
            Philosophers.Lock,
            Philosophers.Confucius,
            Philosophers.Sartre
        };

        private static string[] _forks =
        {
            "Fork0",
            "Fork1",
            "Fork2",
            "Fork3",
            "Fork4"
        };

        public static IEnumerable<Philosopher> NextPhilosophers(this Random rnd, ILogger log, Semaphore sem)
        {
            if (_philosophers.Length <= 0)
            {
                yield break;
            }

            for (int i = 0; i < _philosophers.Length; i++)
            {
                yield return GetPhilosopher(_philosophers[i], log, sem);
            }
        }

        private static Philosopher GetPhilosopher(Philosophers source, ILogger log, Semaphore sem)
        {
            Philosopher philosopher = null;

            switch (source)
            {
                case Philosophers.Kant:
                    philosopher = new KantCreator(log, sem).Create();
                    break;
                case Philosophers.Aristotle:
                    philosopher = new AristotleCreator(log, sem).Create();
                    break;
                case Philosophers.Lock:
                    philosopher = new LockCreator(log, sem).Create();
                    break;
                case Philosophers.Confucius:
                    philosopher = new ConfuciusCreator(log, sem).Create();
                    break;
                case Philosophers.Sartre:
                    philosopher = new SartreCreator(log, sem).Create();
                    break;
                default:
                    break;
            }

            return philosopher;
        }

        public static IEnumerable<Fork> NextForks(this Random rnd)
        {
            if (_forks.Length <= 0)
            {
                yield break;
            }

            for (int i = 0; i < _forks.Length; i++)
            {
                yield return new Fork(_forks[i]);
            }
        }

        public static IEnumerable<Thread> NextThreads(this Random rnd, ParameterizedThreadStart source)
        {
            for (int i = 0; i < 5; i++)
            {
               yield return new Thread(source);
            }
        }
    }
}

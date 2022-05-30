using System;
using System.Threading;

namespace _2022_05_02_DinnerPhilosopher
{
    internal abstract class Philosopher
    {
        private static readonly Random _rnd = new Random();

        private static Semaphore _waiter;

        private readonly ILogger _logger;

        private int _count;

        public Fork LeftFork { get; set; }

        public Fork RightFork { get; set; }

        public Philosopher(Fork left, Fork right, ILogger log, Semaphore waiter)
        {
            LeftFork = left;
            RightFork = right;
            _logger = log;
            _waiter = waiter;
        }

        public void HaveDinner()
        {
            while (_count < Values.Dinners)
            {
                Think();

                _waiter.WaitOne();

                if (IsForksAvaliable())
                {
                    AquireForks();

                    _count++;

                    Eat();

                    ReleaseForks();
                }
                
                _waiter.Release();
            }
        }

        public bool IsForksAvaliable()
        {
            bool result = true;

            if (LeftFork.IsInUse)
            {
                _logger.Write($"{ToString()} left fork isn't avaliable.");
                result = false;
            }
            else
            {
                _logger.Write($"{ToString()} left fork is avaliable.");
            }

            if (RightFork.IsInUse)
            {
                _logger.Write($"{ToString()} right fork isn't avaliable.");
                result = false;
            }
            else
            {
                _logger.Write($"{ToString()} right fork is avaliable.");
            }

            return result;
        }

        public void AquireForks()
        {
            _logger.Write($"{ToString()} is taking forks.");

            RightFork.IsInUse = true;
            LeftFork.IsInUse = true;
        }

        public void ReleaseForks()
        {
            _logger.Write($"{ToString()} is releasing forks.");

            LeftFork.IsInUse = false;
            RightFork.IsInUse = false;
        }

        public void Think()
        {
            _logger.Write($"{ToString()} is thinking.");
            Thread.Sleep(_rnd.Next(Values.MinDuration, Values.MaxDuration));
        }

        public void Eat()
        {
            _logger.Write($"{ToString()} is eating {_count}.");
            Thread.Sleep(_rnd.Next(Values.MinDuration, Values.MaxDuration));
        }
    }
}

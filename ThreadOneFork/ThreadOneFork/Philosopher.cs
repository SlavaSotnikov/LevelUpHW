using System;
using System.Threading;

namespace ThreadOneFork
{
    internal abstract class Philosopher
    {
        private static readonly Random _rnd = new Random();

        private static object _sync = new object();

        private readonly ILogger _logger;

        public Fork Fork { get; set; }

        public string Name { get; set; }

        //public PhilosopherStatus Status { get; set; }

        public Philosopher(Fork fork, string name, ILogger log)
        {
            Fork = fork;
            _logger = log;
            Name = name;
            //Status = PhilosopherStatus.Nothing;
        }

        public void HaveDinner()
        {
            for (;;)
            {
                lock (_sync)
                {
                    _logger.Write($"{Thread.CurrentThread.ManagedThreadId} {this}" +
                           $" is looking for an avaliable fork.");

                    if (IsForkAvaliable())
                    {
                        _logger.Write($"{Thread.CurrentThread.ManagedThreadId} {this} is taking the fork.");
                        AquireForks();


                        _logger.Write($"{Thread.CurrentThread.ManagedThreadId} {this} is eating.");
                        Eat();

                        _logger.Write($"{Thread.CurrentThread.ManagedThreadId} {this} is putting the fork.");
                        ReleaseForks();
                    }
                    else
                    {
                        _logger.Write($"{Thread.CurrentThread.ManagedThreadId} {this} is thinking.");
                        Think();
                    }
                }
            }
        }

        public bool IsForkAvaliable()
        {
            if (Fork.IsInUse)
            {
                _logger.Write($"{Thread.CurrentThread.ManagedThreadId} {this} fork isn't avaliable.");
                return false;
            }
            else
            {
                _logger.Write($"{Thread.CurrentThread.ManagedThreadId} {this} fork is avaliable.");
                return true;
            }
        }

        public void AquireForks()
        {
            Fork.WhichPhilosopher = this;
        }

        public void ReleaseForks()
        {
            Fork.WhichPhilosopher = null;
        }

        public void Think()
        {
            Thread.Sleep(_rnd.Next(50, 1000));
        }

        public void Eat()
        {
            Thread.Sleep(_rnd.Next(50, 1000));
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}

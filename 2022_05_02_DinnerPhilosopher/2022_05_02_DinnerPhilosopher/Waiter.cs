using System.Threading;

namespace _2022_05_02_DinnerPhilosopher
{
    internal class Waiter
    {
        private static Semaphore _instance;

        private Waiter() {}

        public static Semaphore GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Semaphore(2, 5);
            }

            return _instance;
        }
    }
}

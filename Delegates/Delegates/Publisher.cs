using System;

namespace Delegates
{
    internal delegate void NewIterationStart(int number);

    internal class Publisher
    {
        private NewIterationStart _doNewIteration;

        public void NewIterationSubscribe(NewIterationStart doNewIteration)
        {
            _doNewIteration += doNewIteration;
        }

        public void Run(int iterationCount)
        {
            for (int i = 0; i < iterationCount; i++)
            {
                if (_doNewIteration != null)
                {
                    _doNewIteration.Invoke(i);
                }

                Console.WriteLine("Time: {0}", DateTime.Now.ToLongTimeString());

                System.Threading.Thread.Sleep(500);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Threads_2022_02_05
{
    internal class DoubleThread
    {
        private const int ITERATIONS_COUNT = 100;

        private int _count = 0;

        private readonly Thread th1 = null;
        private readonly Thread th2 = null;

        private readonly ILoger _log = null;

        private int[] _initOne;
        private int[] _initTwo;

        public DoubleThread(ILoger log)
        {
            _log = log;

            th1 = new Thread(GetSelectionSort);
            th2 = new Thread(GetSelectionSort);
        }

        public int Count
        {
            get 
            { 
                return _count; 
            }
        }

        public void ParallelSort(int[] one, int[] two)
        {
            if (one is null || two is null)
            {
                return;
            }

            _initOne = one;
            _initTwo = two;

            th1.Start();
            th2.Start();
        }

        public void GetInsertionSort()
        {
            _log.Write("Thread #1 Start InsertionSort");

            int i = 0;
            int memory = 0;

            while (i < _initOne.Length - 1)
            {
                if (_initOne[i] > _initOne[i + 1])
                {
                    int tmp = _initOne[i];
                    _initOne[i] = _initOne[i + 1];
                    _initOne[i + 1] = tmp;

                    if (i != 0)
                    {
                        i--;
                    }
                    else
                    {
                        memory++;
                        i = memory;
                    }
                }
                else
                {
                    memory++;
                    i = memory;
                }
            }

            _log.Write("Thread #1 Finish InsertionSort");
            Console.WriteLine("Thread #1 Finish InsertionSort");
        }

        public void GetSelectionSort(object source)
        {
            if (source is null)
            {
                return;
            }

            int[] arr = source as int[];

            if (arr is null)
            {
                return;
            }

            //_log.Write("Thread #2 Start SelectionSort");

            int index = 0;

            for (int j = 1; j < arr.Length; j++)
            {
                for (int i = j; i < arr.Length; i++)
                {
                    if (arr[index] > arr[i])
                    {
                        int tmp = arr[index];
                        arr[index] = arr[i];
                        arr[i] = tmp;
                    }
                }

                index++;
            }

            //_log.Write("Thread #2 FInish SelectionSort");
            Console.WriteLine("Thread #1 Finish SelectionSort");
        }
    }
}

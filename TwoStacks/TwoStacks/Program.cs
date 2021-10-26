using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoStacks
{
    internal class Program
    {
        static void Main()
        {
            StackG<int> stackG = new StackG<int>();
            stackG.Push(1);
            stackG.Push(2);
            stackG.Push(3);
            stackG.Push(4);

            stackG.Pop();
            stackG.Pop();

            Console.WriteLine(stackG.Amount);

            Console.ReadKey();
        }
    }
}

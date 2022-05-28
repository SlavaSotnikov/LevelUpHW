using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foreach
{
    class Node
    {
        public int Value { get; set; }
    }

    internal class Program
    {
        static void Main()
        {
            List<Node> elements = new List<Node>();

            Parallel.For(0, 1000, i => elements.Add(new Node() { Value = i }));

            elements[301].Value = -1;

            Action<Node, ParallelLoopState> transform = (Node node, ParallelLoopState state) =>
            {
                if (node.Value < 0)
                {
                    state.Break();
                }

                node.Value++;
            };

            ParallelLoopResult result = Parallel.ForEach(elements, transform);

            if (!result.IsCompleted)
            {
                Console.WriteLine(result.LowestBreakIteration);
            }

            Console.ReadKey();
        }
    }
}

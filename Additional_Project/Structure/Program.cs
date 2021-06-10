using System;

namespace Structure
{
    class Program
    {
        const int DEFAULT_CAPACITY = 10;
        static void Main()
        {
            B container1 = new B()
            {
                items = new A[DEFAULT_CAPACITY]
            };

            A a1 = new A() { values = new int[] { 0, 0 }, data = 0 };

            for (int i = 0; i < 5; i++)
            {
                Add(ref container1, a1);

                for (int j = 0; j < a1.values.Length; j++)
                {
                    ++a1.values[j];
                    ++a1.data;
                }
            }


            A a1 = new A() { values = new int[] {0, 0} };

            for (int i = 0; i < 5; i++)
            {
                Add(ref container1, a1);

                for (int j = 0; j < a1.values.Length; j++)
                {
                    ++a1.values[j];
                }
            }

            for (int i = 0; i < container1.size; i++)
            {
                for (int j = 0; j < container1.items[j].values.Length; j++)
                {
                    Console.Write("{0}\t", container1.items[i].values[j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static void Add(ref B container, A item)
        {
            if (container.size < container.items.Length)
            {
                container.items[container.size++] = GetFullCopy(item);
            }
        }

        public static A GetFullCopy(A source)
        {
            // 1)
            //A destination = source;

            // 2)
            A destination = new A();


            destination.values = new int[source.values.Length];
            for (int i = 0; i < source.values.Length; i++)
            {
                destination.values[i] = source.values[i];
            }

            return destination;
        }
    }
}

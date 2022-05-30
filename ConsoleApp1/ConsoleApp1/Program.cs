using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Students
    {
        public string StuName { get; set; }
        public int GrPoint { get; set; }
        public int StuId { get; set; }
    }

    internal class Program
    {
        private static readonly Random _rnd = new Random();

        static void Main()
        {
            //Task 1
            string[] source = { "cognac", "anthem", "CalC", "opel", "targeting" };

            var result = from n in source
                where n.ToLower()[0] == 'c' && n.ToLower()[n.Length - 1] == 'c'
                select n;

            var res = source.Where(n=>n.ToLower()[0] == 'c')
                                           .Where(n=>n.ToLower()[n.Length - 1] == 'c');

            // Task 2
            var res1 = from n in source
                orderby n.Length
                select n.Length;

            var res2 = source.OrderBy(n => n.Length).Select(n=>n.Length);

            // Task 3
            var res3 = from n in source
                let first = n[0]
                let last = n[n.Length - 1]
                select $"{first}{last}";

            var res4 = source.Select(n => n[0])
                    .Concat(source.Select(n => n[n.Length - 1]));

            // Task 4
            string[] source1 = { "IUOHJF1", "IUOHER2", "2NNBG", "ASDF5GH" };

            int length = 7;

            var res5 = from n in source1
                where n.Length == length && char.IsDigit(n[n.Length - 1])
                       orderby n
                       select n;

            var res6 = source1
                    .OrderBy(n=> length)
                    .Where(n => n.Length == length 
                                    && char.IsDigit(n[n.Length - 1]));

            // Task 5
            int[] source2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            var res7 = from n in source2
                       where n % 2 != 0
                           orderby n
                       select n.ToString();

            var res8 = source2.Where(n => n % 2 != 0).OrderBy(n => n);

        // Task 6
            int[] numbers = { 4, 1, 6, 3, 12 };
            string[] stringList = { "2qwe", "4qwe", "5", "3qwe", "7qwert", "1 the 12long" };

            var res9 = from n in numbers
                                      from s in stringList
                                        where n == s.Length && char.IsDigit(s[0])
                                      select s;

            var res10 = numbers
                .Select(n => stringList.FirstOrDefault(s=>s.Length == n && char.IsDigit(s[0])) ?? "Not Found");


            // Task 7


            foreach (var item in res10)
            {
                Console.Write($"{item} ");
            }

            Console.ReadKey();
        }
    }
}

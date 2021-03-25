using System;

namespace Task1
{
    class Program
    {
        static void Main()
        {
            int pre = 0;

            Console.Write(pre + " " + ++pre + " " + pre); // The result: 0, 1 , 1

            Console.WriteLine();

            int post = 0;

            Console.Write(post + " " + post++ + " " + post); // The result: 0, 0 , 1

            Console.ReadLine();


            /*    Conclusion
             *    
             *  In sum it up we can say that Prefix increment operator is a bit quickly than Postfix.  
             *  I guess that is the cause:
             *  
             *  Result == ++pre;
             *  Result == post++ + "Assignment operation";
            */



        }
    }
}

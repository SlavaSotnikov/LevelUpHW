using System;

namespace Swap_Method
{
    class Program
    {
        static int Swap10(int num1, ref int num2)
        {
            int temp = num2;
            num2 = num1;
            return temp;
        }

        static void Swap9(int b, ref int num1, out int num2)
        {
            num2 = num1;
            num1 = b; 
        }

        static int Swap8(int a, int b, out int num1)
        {
            num1 = b;
            return a;
        }
        static void Swap7(int a, int b, out int num1, out int num2)
        {
            num1 = b;
            num2 = a;
        }

        //Out

        static void Swap6(ref int num1, ref int num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
        }

        static void Swap5(ref int num1, ref int num2)
        {
            int difference = num1 - num2;
            num1 -=difference;
            num2 += difference; 
        }

        static void Swap4(ref int num1, ref int num2)
        {
            byte res = (byte)(num1 ^ num2);
            num1 = (byte)(res ^ num1);
            num2 = (byte)(res ^ num2);
        }

        static void Swap3(ref int num1, ref int num2)
        {
            int product = num1 * num2;
            num1 /= product;
            num2 /= product;
        }

        static void Swap2(ref int num1, ref int num2) => (num1, num2) = (num2, num1); 

        static void Swap1(ref int num1, ref int num2)
        {
            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;
        }
        
        static void Swap(ref int num1, ref int num2)
        {
            int sum = num1 + num2;
            num1 -= sum;
            num2 -= sum;
        }

        //ref
         
        static void Main()
        {
            int num1 = 10;
            int num2 = 5;

            //for Out
            int a = num1;
            int b = num2;

            //Swap(ref num1, ref num2);

            //Swap1(ref num1, ref num2);

            //Swap2(ref num1, ref num2);

            //Swap3(ref num1, ref num2);

            //Swap4(ref num1, ref num2);

            //Swap5(ref num1, ref num2);

            //Swap6(ref num1, ref num2);

            //Out

            //Swap7(a, b, out num1, out num2);

            //Swap9(b, ref num1, out num2);


            Console.WriteLine("IN num1 = {0} num2 = {1}", 10, 5);

            // ref

            //Console.WriteLine("OUT Swap() num1 = {0} num2 = {1}", num1, num2);

            //Console.WriteLine("OUT Swap1() num1 = {0} num2 = {1}", num1, num2);

            //Console.WriteLine("OUT Swap2() num1 = {0} num2 = {1}", num1, num2);

            //Console.WriteLine("OUT Swap3() num1 = {0} num2 = {1}", num1, num2);

            //Console.WriteLine("OUT Swap4() num1 = {0} num2 = {1}", num1, num2);

            //Console.WriteLine("OUT Swap5() num1 = {0} num2 = {1}", num1, num2);

            //Console.WriteLine("OUT Swap6() num1 = {0} num2 = {1}", num1, num2);

            //Out

            //Console.WriteLine("OUT Swap7() num1 = {0} num2 = {1}", num1, num2);

            //num2 = Swap8(a, b, out num1);
            //Console.WriteLine("OUT Swap8() num1 = {0} num2 = {1}", num1, num2);

            //Console.WriteLine("OUT Swap9() num1 = {0} num2 = {1}", num1, num2);

            num1 = Swap10(num1, ref num2);
            Console.WriteLine("OUT Swap10() num1 = {0} num2 = {1}", num1, num2);
           
            Console.ReadKey();
        }
    }
}

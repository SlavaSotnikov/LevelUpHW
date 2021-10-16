using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_method
{
    internal class Program
    {
        delegate void MessageHandler(string message);
        static void Main(string[] args)
        {
            ShowMessage("hello!", (mes) => { Console.WriteLine(mes); });

            Console.Read();
        }
        static void ShowMessage(string mes, MessageHandler handler)
        {
            handler.Invoke(mes);
        }
    }
}

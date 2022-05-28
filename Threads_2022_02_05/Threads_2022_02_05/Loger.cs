using System;
using System.IO;

namespace Threads_2022_02_05
{
    internal class Loger : ILoger, IDisposable
    {
        private TextWriter _writer = new StreamWriter("Log.txt", true);

        public void Write(string message)
        {
            _writer.WriteLine($"|{DateTime.Now.Millisecond}| - {message}");
        }

        public void Dispose()
        {
            _writer.Dispose();
        }
    }
}

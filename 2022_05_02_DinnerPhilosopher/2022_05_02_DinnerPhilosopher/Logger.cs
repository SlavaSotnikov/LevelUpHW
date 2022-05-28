using System;
using System.IO;

namespace _2022_05_02_DinnerPhilosopher
{
    internal class Logger : ILogger, IDisposable
    {
        private const string FILE_NAME = "Log.txt";
        private object _sync = new object();

        private StreamWriter _writer;
        private BufferedStream _buffer;

        public Logger(string fileName = FILE_NAME)
        {
            _writer = new StreamWriter(fileName, true);
            _buffer = new BufferedStream(_writer.BaseStream, int.MaxValue);
        }

        public void Write(string message)
        {
            _writer.WriteLine($"{DateTime.Now.ToLocalTime()} {message}");
        }

        public void Dispose()
        {
            _writer?.Dispose();
            _buffer?.Flush();
        }
    }
}

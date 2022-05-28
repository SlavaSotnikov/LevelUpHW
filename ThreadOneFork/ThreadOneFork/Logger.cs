using System;
using System.IO;

namespace ThreadOneFork
{
    internal class Logger: IDisposable, ILogger
    {
        private const string FILE_NAME = "Log.txt";

        private StreamWriter _writer;
        private BufferedStream _buffer;

        public Logger(string fileName = FILE_NAME)
        {
            _writer = new StreamWriter(fileName, true);
            _buffer = new BufferedStream(_writer.BaseStream, int.MaxValue);
        }

        public void Write(string message)
        {
            _writer.WriteLine(message);
        }

        public void Dispose()
        {
            _writer?.Dispose();
            _buffer?.Flush();
        }
    }
}

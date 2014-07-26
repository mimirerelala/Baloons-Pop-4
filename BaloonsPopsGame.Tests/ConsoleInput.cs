namespace BaloonsPopsGame.Tests
{
    using System;
    using System.IO;

    public class ConsoleInput : IDisposable
    {
        private StringReader stringReader;
        private TextReader originalOutput;

        public ConsoleInput(string input)
        {
            this.stringReader = new StringReader(input);
            this.originalOutput = Console.In;
            Console.SetIn(this.stringReader);
        }

        public void Dispose()
        {
            Console.SetIn(this.originalOutput);
            this.stringReader.Dispose();
        }
    }
}

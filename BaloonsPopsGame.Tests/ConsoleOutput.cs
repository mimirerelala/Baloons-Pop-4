namespace BaloonsPopsGame.Tests.Utilities
{
    using System;
    using System.IO;

    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter originalOutput;

        public ConsoleOutput()
        {
            this.stringWriter = new StringWriter();
            this.originalOutput = Console.Out;
            Console.SetOut(this.stringWriter);
        }

        public string GetOuput()
        {
            return this.stringWriter.ToString();
        }

        public void ResetOutput() 
        {
            this.stringWriter = new StringWriter();
            Console.SetOut(this.stringWriter);
        }

        public void Dispose()
        {
            Console.SetOut(this.originalOutput);
            this.stringWriter.Dispose();
        }
    }
}

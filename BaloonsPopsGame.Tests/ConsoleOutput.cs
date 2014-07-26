namespace BaloonsPopsGame.Tests.Utilities
{
    using System;
    using System.IO;

    /// <summary>
    /// Auxiliary class to redirect console output.
    /// </summary>
    public class ConsoleOutput : IDisposable
    {
        /// <summary>
        /// The object to set the console output to.
        /// </summary>
        private StringWriter stringWriter;

        /// <summary>
        /// Stores the original console output.
        /// </summary>
        private TextWriter originalOutput;

        /// <summary>
        /// 
        /// </summary>
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

namespace BaloonsPopsGame.Tests
{
    using System;
    using System.IO;

    /// <summary>
    /// Auxiliary class for testing  console input methods.
    /// </summary>
    public class ConsoleInput : IDisposable
    {
        /// <summary>
        /// A reader to which the console in is redirected.
        /// </summary>
        private StringReader stringReader;

        /// <summary>
        /// The original console output.
        /// </summary>
        private TextReader originalOutput;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutput" /> class.
        /// </summary>
        /// <param name="input">The new path for console input.</param>
        public ConsoleInput(string input)
        {
            this.stringReader = new StringReader(input);
            this.originalOutput = Console.In;
            Console.SetIn(this.stringReader);
        }

        /// <summary>
        /// Restores the default console in.
        /// </summary>
        public void Dispose()
        {
            Console.SetIn(this.originalOutput);
            this.stringReader.Dispose();
        }
    }
}

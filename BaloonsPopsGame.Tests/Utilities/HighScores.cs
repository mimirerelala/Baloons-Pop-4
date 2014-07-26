namespace BaloonsPopsGame.Tests.Utilities
{
    using System;
    using System.IO;
    using BaloonsPopsGame.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HighScoresTest
    {
        [TestMethod]
        public void HighScoresSavesToFile()
        {
            var input = new string[0, 0];
            var path = "testInput.txt";
            HighScores.Save(input, path);
            string result;

            using (var reader = new StreamReader(path))
            {
                result = reader.ReadToEnd();
            }

            var expected = "0" + Environment.NewLine + "0" + Environment.NewLine;

            Assert.AreEqual(expected, result);
            File.Delete(path);
        }

        [TestMethod]
        public void HighScoresSavesAndLoadsTheSame()
        {
            var input = new string[0, 0];
            var path = "testInput.txt";
            HighScores.Save(input, path);

            var result = HighScores.Load(path);

            foreach (var item in result)
            {
                Assert.AreEqual(input, result);
            }

            File.Delete(path);
        }
    }
}

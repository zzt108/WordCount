using System;
using WordCount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void CanSpecifyNoFileNameArgument()
        {
            var retVal = Program.Main(null);
            Assert.AreEqual(1, retVal, "Incorrect error code returned");
        }

        [TestMethod]
        public void CanSpecifyNonExistingFileNameArgument()
        {
            var retVal = Program.Main(new[] { "xxxxx.txt" });
            Assert.AreEqual(2, retVal, "Incorrect error code returned");
        }

        [TestMethod]
        public void CanSpecifyExistingFileNameArgument()
        {
            var retVal = Program.Main(new[] { "WordCount.exe.config" });
            Assert.AreEqual(0, retVal, "Incorrect error code returned");
        }

        private bool CheckWord(Dictionary<string, int> result, string key, int count)
        {
            Assert.IsTrue(result.ContainsKey(key), $"Expected word '{key}' not found");
            Assert.AreEqual(count, result[key], $"Word '{key}' count is not correct");
            return true;
        }

        [TestMethod]
        public void CanExecuteHappyPath()
        {
            var text = new[] { "Go do that thing that you do so well" };
            var result = Program.GetUniqueWords(text, Program.WordRegEx);
            Assert.AreEqual(7, result.Count);
            CheckWord(result, "go", 1);
            CheckWord(result, "do", 2);
            CheckWord(result, "that", 2);
            CheckWord(result, "thing", 1);
            CheckWord(result, "you", 1);
            CheckWord(result, "so", 1);
            CheckWord(result, "well", 1);
        }

        [TestMethod]
        public void CanSelectWordsOnly()
        {
            var text = new[] { "Go do that thing, that you, do so well . !" };
            var result = Program.GetUniqueWords(text, Program.WordRegEx);
            Assert.AreEqual(7, result.Count);
            CheckWord(result, "go", 1);
            CheckWord(result, "do", 2);
            CheckWord(result, "that", 2);
            CheckWord(result, "thing", 1);
            CheckWord(result, "you", 1);
            CheckWord(result, "so", 1);
            CheckWord(result, "well", 1);
        }
    }
}

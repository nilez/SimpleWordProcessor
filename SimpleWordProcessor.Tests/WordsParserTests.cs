using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWordProcessor.Library;
using System.Collections.Generic;
using System.Linq;

namespace SimpleWordProcessor.Tests
{
    [TestClass]
    public class WordsParserTests
    {
        [TestMethod]
        public void OnParsing_GetWords_RemovesSpecialCharacters()
        {
            string input = "\r\n    .,;/?\"'!&*[](){}";

            WordsParser parser = new WordsParser();
            IEnumerable<string> words= parser.GetWords(input);

            Assert.AreEqual(0, words.Count());
        }

        [TestMethod]
        public void OnParsing_GetWords_DoesNotRemoveHypen()
        {
            string input = "\r\n    .,;/?\"'!&*[](-){}";

            WordsParser parser = new WordsParser();
            IEnumerable<string> words = parser.GetWords(input);

            Assert.AreEqual(1, words.Count());
            Assert.AreEqual(true, words.Contains("-"));
        }

        [TestMethod]
        public void OnParsing_GetWords_ConsidersHypenatedAsSingleWord()
        {
            string input = "co-operate";

            WordsParser parser = new WordsParser();
            IEnumerable<string> words = parser.GetWords(input);

            Assert.AreEqual(1, words.Count());            
        }

        [TestMethod]
        public void OnParsing_GetWords_RetrievesWordsFromText()
        {
            string input = "Our time in the world is a loan, we must pay it with interest.";

            WordsParser parser = new WordsParser();
            IEnumerable<string> words = parser.GetWords(input);

            Assert.AreEqual(14, words.Count());
            Assert.AreEqual("Ourtimeintheworldisaloanwemustpayitwithinterest", words.Aggregate((a, b) => a + b));
        }

        [TestMethod]
        public void OnParsing_GetWords_IgnoresNewLines()
        {
            string input = @"Our time in the world is 
                a loan, we must pay it with interest. 
                and 
                another line";

            WordsParser parser = new WordsParser();
            IEnumerable<string> words = parser.GetWords(input);

            Assert.AreEqual(17, words.Count());
            Assert.AreEqual("Ourtimeintheworldisaloanwemustpayitwithinterestandanotherline", words.Aggregate((a, b) => a + b));
        }
    }
}

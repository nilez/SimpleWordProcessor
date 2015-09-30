using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWordProcessor.Library;
using System.Linq;

namespace SimpleWordProcessor.Tests
{
    [TestClass]
    public class WordsCounterTests
    {
        [TestMethod]
        public void OnCounting_WordsCounter_CountsSingleWord()
        {
            WordsCounter counter = new WordsCounter();
            var word = "random";

            counter.ProcessEach(word);

            var listAppearances = counter.Appearances.ToList();
            CounterEntry entryForNew = listAppearances.Find(c => c.Word == word);
            Assert.IsNotNull(entryForNew);
            Assert.AreEqual(word, entryForNew.Word);
            Assert.AreEqual(1, entryForNew.Count);
        }

        [TestMethod]
        public void OnCounting_WordsCounter_CountsWordRepeatingTwoTimes()
        {
            WordsCounter counter = new WordsCounter();
            var word = "random";

            counter.ProcessEach(word);
            counter.ProcessEach(word);

            var listAppearances = counter.Appearances.ToList();
            CounterEntry entryForNew = listAppearances.Find(c => c.Word == word);
            Assert.IsNotNull(entryForNew);
            Assert.AreEqual(word, entryForNew.Word);
            Assert.AreEqual(2, entryForNew.Count);
        }

        [TestMethod]
        public void OnCounting_WordsCounter_CountsWordsInAnArray()
        {
            WordsCounter counter = new WordsCounter();
            // 16 words, the and loan occur 2 times each.
            var words = new string[] { "Our", "time", "in", "the", "world", "is", "on", "loan", "we", "must", "pay", "back", "the", "loan", "with", "interest" };

            foreach (var word in words)
            {
                counter.ProcessEach(word);
            }


            var listAppearances = counter.Appearances.ToList();            
            var loanEntry = listAppearances.Find(w => w.Word == "loan");
            var theEntry = listAppearances.Find(w => w.Word == "the");
            
            Assert.AreEqual(14, listAppearances.Count);
            Assert.AreEqual(12, listAppearances.FindAll(c=>c.Count==1).Count);
            Assert.AreEqual(2, loanEntry.Count);
            Assert.AreEqual("loan", loanEntry.Word);
            Assert.AreEqual(2, theEntry.Count);
            Assert.AreEqual("the", theEntry.Word);            
        }
    }
}

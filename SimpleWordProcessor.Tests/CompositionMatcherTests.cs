using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWordProcessor.Library;
using System.Linq;

namespace SimpleWordProcessor.Tests
{
    [TestClass]
    public class CompositionMatcherTests
    {
        [TestMethod]
        public void OnMatching_CompositionMatcher_DoesNotFindCompostionMissingSecondPart()
        {
            var words = new string[] { "sure", "it", "itself" };
            CompositionMatcher matcher = new CompositionMatcher(words, 6);

            foreach (var word in words)
            {
                matcher.ProcessEach(word);
            }

            var matches = matcher.Matches.ToList();
            Assert.AreEqual(0, matches.Count);            
        }

        [TestMethod]
        public void OnMatching_CompositionMatcher_MatchesCompositionOfLength7()
        {
            var words = new string[] { "self", "her", "herself" };
            CompositionMatcher matcher = new CompositionMatcher(words, 7);

            foreach (var word in words)
            {
                matcher.ProcessEach(word);
            }

            var matches = matcher.Matches.ToList();
            Assert.AreEqual(1, matches.Count);
            Assert.AreEqual("her", matches[0].FirstPart);
            Assert.AreEqual("self", matches[0].SecondPart);
            Assert.AreEqual("herself", matches[0].Composition);
        }

        [TestMethod]
        public void OnMatching_CompositionMatcher_MatchesSingleComposition()
        {
            var words = new string[] { "self", "it", "itself" };
            CompositionMatcher matcher = new CompositionMatcher(words, 6);

            foreach (var word in words)
            {
                matcher.ProcessEach(word);
            }

            var matches = matcher.Matches.ToList();
            Assert.AreEqual(1, matches.Count);
            Assert.AreEqual("it", matches[0].FirstPart);
            Assert.AreEqual("self", matches[0].SecondPart);
            Assert.AreEqual("itself", matches[0].Composition);
        }

        [TestMethod]
        public void OnMatching_CompositionMatcher_MatchesTwoCompositionsWithSameFirstPart()
        {
            var words = new string[] { "alic","self", "it", "itself", "italic"};
            CompositionMatcher matcher = new CompositionMatcher(words, 6);

            foreach (var word in words)
            {
                matcher.ProcessEach(word);
            }

            var matches = matcher.Matches.ToList();
            Assert.AreEqual(2, matches.Count);

            var selfEntry = matches.Find(e => e.SecondPart == "self");
            var alicEntry = matches.Find(e => e.SecondPart == "alic");

            Assert.AreEqual("it", selfEntry.FirstPart);
            Assert.AreEqual("self", selfEntry.SecondPart);
            Assert.AreEqual("itself", selfEntry.Composition);

            Assert.AreEqual("it", alicEntry.FirstPart);
            Assert.AreEqual("alic", alicEntry.SecondPart);
            Assert.AreEqual("italic", alicEntry.Composition);
        }

        [TestMethod]
        public void OnMatching_CompositionMatcher_MatchesTwoCompositionsWithSameSecondPart()
        {
            var words = new string[] { "my", "self", "it", "itself", "myself" };
            CompositionMatcher matcher = new CompositionMatcher(words, 6);

            foreach (var word in words)
            {
                matcher.ProcessEach(word);
            }

            var matches = matcher.Matches.ToList();
            Assert.AreEqual(2, matches.Count);

            var myEntry = matches.Find(e => e.FirstPart == "my");
            var itEntry = matches.Find(e => e.FirstPart == "it");

            Assert.IsNotNull(itEntry);
            Assert.AreEqual("it", itEntry.FirstPart);
            Assert.AreEqual("self", itEntry.SecondPart);
            Assert.AreEqual("itself", itEntry.Composition);

            Assert.IsNotNull(myEntry);
            Assert.AreEqual("my", myEntry.FirstPart);
            Assert.AreEqual("self", myEntry.SecondPart);
            Assert.AreEqual("myself", myEntry.Composition);
        }

        [TestMethod]
        public void OnMatching_CompositionMatcher_DoesNotFindCompostion()
        {            
            var words = new string[] { "Our", "time", "in", "the", "world", "is", "on", "loan", "we", "must", "pay", "back", "the", "loan", "with", "interest" };
            CompositionMatcher matcher = new CompositionMatcher(words, 7);

            foreach (var word in words)
            {
                matcher.ProcessEach(word);
            }
            
            Assert.AreEqual(0, matcher.Matches.Count());            
        }
    }
}

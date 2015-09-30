using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleWordProcessor.Core;
using Rhino.Mocks;
using SimpleWordProcessor.Library;

namespace SimpleWordProcessor.Tests
{
    [TestClass]
    public class StandardTraverserTests
    {
        [TestMethod]
        public void OnTraversing_AcceptProcessor_TraversesAllWordsInLinearFashoin()
        {
            IEnumerable<string> words = new List<string>() { "Our", "time", "in", "the", "world", "is", "a", "loan", "we", "must", "pay", "it", "with", "interest" };
            IWordProcessor processor = Rhino.Mocks.MockRepository.GenerateMock<IWordProcessor>();
            
            StandardWordTraverser traverser = new StandardWordTraverser(words);
            traverser.AcceptProcessor(processor);

            processor.AssertWasCalled(p => p.ProcessEach(Arg<string>.Is.Anything), options => options.Repeat.Times(words.Count()));
        }
    }
}

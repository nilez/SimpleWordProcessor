using SimpleWordProcessor.Core;
using System.Collections.Generic;

namespace SimpleWordProcessor.Library
{
    public class StandardWordTraverser : IWordTraverser
    {
        IEnumerable<string> words;
        public StandardWordTraverser(IEnumerable<string> words)
        {
            this.words = words;
        }
        public void AcceptProcessor(IWordProcessor processor)
        {
            foreach (var word in words)
            {
                processor.ProcessEach(word);
            }
        }
    }
}

using SimpleWordProcessor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

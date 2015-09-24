using SimpleWordProcessor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWordProcessor.Library
{
    public class WordsCounter : IWordProcessor
    {
        Dictionary<string, int> appearances = new Dictionary<string, int>();
        const string ConsoleFormat = "{0,15}{1,10}";
        public void ProcessEach(string word)
        {
            if (appearances.ContainsKey(word))
                appearances[word] += 1;
            else
                appearances.Add(word, 1);
        }

        public void ReportTo(Action<string> console)
        {
            console("Repoting From WordsCounter:    ");
            console(string.Format(ConsoleFormat, "Word","Count"));
            console(Environment.NewLine);
            foreach (var entry in appearances.OrderBy(x=>x.Key))
            {                
                console(string.Format(ConsoleFormat, entry.Key, entry.Value));
            }
        }
    }
}

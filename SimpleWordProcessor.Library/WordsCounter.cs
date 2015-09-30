using SimpleWordProcessor.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleWordProcessor.Library
{
    public class WordsCounter : IWordProcessor
    {
        readonly List<CounterEntry> appearances = new List<CounterEntry>();

        const string ConsoleFormat = "{0,15}{1,10}";
        public void ProcessEach(string word)
        {
            CounterEntry match = appearances.Find(c => c.Word == word);

            if (match != null)
                match.Count++;
            else
                appearances.Add(new CounterEntry() { Word = word, Count = 1 });
        }

        public void ReportTo(Action<string> console)
        {
            console("Repoting From WordsCounter:    ");
            console(string.Format(ConsoleFormat, "Word", "Count"));
            console(Environment.NewLine);
            foreach (var entry in appearances.OrderBy(c => c.Word))
            {
                console(string.Format(ConsoleFormat, entry.Word, entry.Count));
            }
        }

        public IEnumerable<CounterEntry> Appearances
        {
            get
            {
                return appearances;
            }
        }
    }   
}

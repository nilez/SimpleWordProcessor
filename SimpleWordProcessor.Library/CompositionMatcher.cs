using SimpleWordProcessor.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleWordProcessor.Library
{
    public class CompositionMatcher : IWordProcessor
    {
        readonly List<string> compositions;
        readonly List<string> parts;

        readonly List<CompositionEntry> matches = new List<CompositionEntry>();

        int compositionLength;
        public CompositionMatcher(IEnumerable<string> words, int compositionLength)
        {
            this.compositionLength = compositionLength;
            // all distinct part which can make the composition
            parts = words.Where(x => x.Length < compositionLength).Distinct().ToList();
            // all distinct compositions of given length
            compositions = words.Where(x => x.Length == compositionLength).Distinct().ToList();
        }

        public void ProcessEach(string word)
        {
            if (word.Length >= compositionLength)
                return;

            if (matches.Exists(c => c.FirstPart == word))
                return;

            var matchList = compositions.FindAll(x => x.StartsWith(word) && parts.Contains(x.Substring(word.Length)));

            foreach (var match in matchList)
            {
                matches.Add(new CompositionEntry()
                {
                    FirstPart = word,
                    SecondPart = match.Substring(word.Length)
                });
            }            
        }

        public void ReportTo(Action<string> console)
        {
            console(string.Format("Reporting From CompositonMatcher For Composition Length={0}:", compositionLength));

            foreach (var match in matches)
            {
                console(string.Format("Part 1: {0,15}", match.FirstPart));
                console(string.Format("Part 2: {0,15}", match.SecondPart));
                console(string.Format("Composition: {0,10}", match.Composition));
                console("-----------------------------------");
            }
        }

        public IEnumerable<CompositionEntry> Matches
        {
            get
            {
                return matches;
            }
        }
    }
}

﻿using SimpleWordProcessor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWordProcessor.Library
{
    public class CompositionMatcher : IWordProcessor
    {
        List<string> compositions;
        List<string> parts;

        Dictionary<string, List<string>> matches = new Dictionary<string, List<string>>();
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
            if (matches.ContainsKey(word))
                return;
            var matchList = compositions.FindAll(x => x.StartsWith(word) && parts.Contains(x.Substring(word.Length)));

            foreach (var match in matchList)
            {
                if (!matches.ContainsKey(word))
                {
                    matches.Add(word, new List<string>() { match.Substring(word.Length) });
                }
                else {
                    matches[word].Add(match.Substring(word.Length));
                }
            }
        }

        public void ReportTo(Action<string> console)
        {
            console(string.Format("Reporting From CompositonMatcher For Composition Length={0}:", compositionLength));

            foreach (var match in matches)
            {
                foreach (var item in match.Value)
                {
                    console(string.Format("Part 1: {0,15}", match.Key));
                    console(string.Format("Part 2: {0,15}", item));
                    console(string.Format("Composition: {0,10}", match.Key+ item));
                    console("-----------------------------------");
                }                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWordProcessor.Library
{
    public class WordsParser
    {        
        public WordsParser()
        {            
        }

        public IEnumerable<string> GetWords(string whole)
        {
            var strippedWhole = Regex.Replace(whole, "[^A-Za-z-]", " ", RegexOptions.IgnoreCase);

            var parts = strippedWhole.Split(' ');

            return parts.Where(s => s.Length > 0);
        }
    }
}

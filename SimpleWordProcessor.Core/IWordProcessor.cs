using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWordProcessor.Core
{
    public interface IWordProcessor
    {
        void ProcessEach(string word);
        void ReportTo(Action<string> console);
    }
}

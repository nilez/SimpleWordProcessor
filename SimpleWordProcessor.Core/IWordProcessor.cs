using System;

namespace SimpleWordProcessor.Core
{
    public interface IWordProcessor
    {
        void ProcessEach(string word);
        void ReportTo(Action<string> console);
    }
}

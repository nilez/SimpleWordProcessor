using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWordProcessor.Core
{
    public interface IWordTraverser
    {
        void AcceptProcessor(IWordProcessor processor);
    }
}

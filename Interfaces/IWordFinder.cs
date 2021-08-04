using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Interfaces
{
    public interface IWordFinder
    {
        public IEnumerable<string> Find(IEnumerable<string> wordstream);
    }
}

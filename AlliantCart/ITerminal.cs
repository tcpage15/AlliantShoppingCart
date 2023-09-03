using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlliantCart
{
    public interface ITerminal
    {
        List<string> AddToCheckoutCounter(string items);
        void Scan(string item);
        decimal Total();
    }
}

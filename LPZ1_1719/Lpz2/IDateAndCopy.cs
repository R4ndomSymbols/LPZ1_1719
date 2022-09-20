using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719.Lpz2
{
    public interface IDateAndCopy
    {
        object DeepCopy();

        DateTime Date { get; set; }
    }
}

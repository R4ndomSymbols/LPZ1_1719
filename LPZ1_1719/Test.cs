using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPZ1_1719
{
    public class Test
    {
        public string Name { get; set; }
        public bool IsPassed { get; set; }

        public Test(string name, bool isPassed)
        {
            Name = name;
            IsPassed = isPassed;
        }

        public Test()
        {
            Name = String.Empty;
        }

        public override string ToString()
        {
            return String.Join(" ", Name, IsPassed);
        }
    }
}

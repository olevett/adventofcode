using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day7Operations
{
    public class Constant : IOperation
    {
        private readonly UInt16 value;

        public Constant(UInt16 value)
        {
            this.value = value;
        }

        public UInt16 Calculate()
        {
            return value;
        }
    }
}

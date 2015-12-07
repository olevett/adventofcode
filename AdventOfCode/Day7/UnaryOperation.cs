using System;

namespace AdventOfCode.Day7Operations
{
    public abstract class UnaryOperation : IOperation
    {
        public IOperation Input
        {
            private set;
            get;
        }

        public UnaryOperation(IOperation input)
        {
            Input = input;
        }

        public abstract UInt16 Calculate();
    }
}

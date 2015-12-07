using System;

namespace AdventOfCode.Day7Operations
{
    public abstract class BinaryOperation: IOperation
    {
        public IOperation Left
        {
            private set;
            get;
        }

        public IOperation Right
        {
            private set;
            get;
        }

        public BinaryOperation(IOperation left, IOperation right)
        {
            Left = left;
            Right = right;
        }

        public abstract UInt16 Calculate();
    }
}

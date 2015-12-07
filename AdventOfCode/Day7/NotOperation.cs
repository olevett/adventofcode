using System;

namespace AdventOfCode.Day7Operations
{
    public class NotOperation : UnaryOperation
    {
        public NotOperation(IOperation operation)
            : base(operation)
        {
        }

        public override UInt16 Calculate()
        {
            return (UInt16)~Input.Calculate();
        }
    }
}

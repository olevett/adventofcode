using System;

namespace AdventOfCode.Day7Operations
{
    public class Operation
    {
        private readonly Lazy<UInt16> calculation;

        public Operation(UInt16 input)
        {
            calculation = new Lazy<UInt16>(() => input);
        }

        public Operation(Func<Operation> input, Func<Operation, UInt16> operation)
        {
            calculation = new Lazy<UInt16>(() => operation(input()));
        }

        public Operation(Func<Operation> left, Func<Operation> right, Func<Operation, Operation, UInt16> operation)
        {
            calculation = new Lazy<UInt16>(() => operation(left(), right()));
        }

        public UInt16 Calculate()
        {
            return calculation.Value;
        }

        public static UInt16 LeftShift(Operation left, Operation right)
        {
            return (UInt16)(left.Calculate() << right.Calculate());
        }

        public static UInt16 RightShift(Operation left, Operation right)
        {
            return (UInt16)(left.Calculate() >> right.Calculate());
        }

        public static UInt16 And(Operation left, Operation right)
        {
            return (UInt16)(left.Calculate() & right.Calculate());
        }

        public static UInt16 Or(Operation left, Operation right)
        {
            return (UInt16)(left.Calculate() | right.Calculate());
        }

        public static UInt16 Not(Operation value)
        {
            return (UInt16)~value.Calculate();
        }

        public static UInt16 Load(Operation value)
        {
            return value.Calculate();
        }
    }
}
using AdventOfCode.Day7Operations;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day7Operations
{
    public class OperationTests
    {
        [Theory]
        [InlineData(1, 1, 2)]
        public void LeftShift(UInt16 input, UInt16 shiftAmount, UInt16 output)
        {
            var actual = Operation.LeftShift(new Operation(input), new Operation(shiftAmount));
            Assert.Equal(output, actual);
        }

        [Theory]
        [InlineData(2, 1, 1)]
        public void RightShift(UInt16 input, UInt16 shiftAmount, UInt16 output)
        {
            var actual = Operation.RightShift(new Operation(input), new Operation(shiftAmount));
            Assert.Equal(output, actual);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        [InlineData(0, 0, 0)]
        public void Or(UInt16 left, UInt16 right, UInt16 expected)
        {
            var actual = Operation.Or(new Operation(left), new Operation(right));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(0, 1, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 0)]
        public void And(UInt16 left, UInt16 right, UInt16 expected)
        {
            var actual = Operation.And(new Operation(left), new Operation(right));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 65535)]
        public void Not(UInt16 input, UInt16 expected)
        {
            var actual = Operation.Not(new Operation(input));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(0, 0)]
        public void Calculate(UInt16 input, UInt16 expected)
        {
            var actual = Operation.Load(new Operation(input));
            Assert.Equal(expected, actual);
        }
    }
}

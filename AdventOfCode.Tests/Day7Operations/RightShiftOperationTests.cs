using AdventOfCode.Day7Operations;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day7Operations
{
    public class RightShiftOperationTests
    {
        [Theory]
        [InlineData(2, 1, 1)]
        public void RightShift(UInt16 input, UInt16 shiftAmount, UInt16 output)
        {
            var operation = new RightShiftOperation(new Constant(input), new Constant(shiftAmount));
            var actual = operation.Calculate();

            Assert.Equal(output, actual);
        }
    }
}

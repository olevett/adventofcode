using AdventOfCode.Day7Operations;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day7Operations
{
    public class LeftShiftOperationTests
    {
        [Theory]
        [InlineData(1, 1, 2)]
        public void LeftShift(UInt16 input, UInt16 shiftAmount, UInt16 output)
        {
            var leftShiftOperator = new LeftShiftOperation(new Constant(input), new Constant(shiftAmount));
            var actual = leftShiftOperator.Calculate();

            Assert.Equal(output, actual);
        }
    }
}

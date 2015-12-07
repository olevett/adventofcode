using AdventOfCode.Day7Operations;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day7Operations
{
    public class NotOperationTests
    {
        [Theory]
        [InlineData(0, 65535)]
        public void Calculate(UInt16 input, UInt16 expected)
        {
            var inputOp = new Constant(input);
            var not = new NotOperation(inputOp);
            var actual = not.Calculate();

            Assert.Equal(expected, actual);
        }
    }
}

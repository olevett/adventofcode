using AdventOfCode.Day7Operations;
using Ploeh.AutoFixture.Xunit2;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day7Operations
{
    public class ConstantTests
    {
        [Theory, AutoData]
        public void ConstantReturnsSetValue(UInt16 expectedNumber)
        {
            var constant = new Constant(expectedNumber);
            var actual = constant.Calculate();
            Assert.Equal(expectedNumber, actual);
        }
    }
}

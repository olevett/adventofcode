using AdventOfCode.Day7Operations;
using System;
using Xunit;

namespace AdventOfCode.Tests.Day7Operations
{
    public class OperationDictionaryTests
    {
        [Theory]
        [InlineData("0", 0)]
        [InlineData("999", 999)]
        [InlineData("empty", 0)]
        public void AutoGeneratesValuesCorrectly(string key, UInt16 expectedValue)
        {
            var operationDictionary = new OperationDictionary();
            var actual = operationDictionary[key].Calculate();
            Assert.Equal(expectedValue, actual);
        }
    }
}

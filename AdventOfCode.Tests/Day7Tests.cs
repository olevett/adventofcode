using AdventOfCode.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day7Tests
    {
        [Theory]
        [InlineData("123 -> x", "x", "123")]
        [InlineData("456 -> y", "y", "456")]
        public void GetInstructionDictionary(string input, string expectedKey, string expectedValue)
        {
            var day7 = new Day7();
            var output = day7.GetInstructionDictionary(new List<string>() { input });

            Assert.Contains(output, x => x.Key == expectedKey && x.Value == expectedValue);
        }

        [Theory]
        [InlineData("a", "123 -> a", 123)]
        [InlineData("a", "b -> a\r\n123 -> b", 123)]
        [InlineData("a", "NOT 0 -> a", 65535)]
        [InlineData("a", "NOT b -> a\r\n0 -> b", 65535)]
        [InlineData("d", SimpleTestCase, 72)]
        [InlineData("e", SimpleTestCase, 507)]
        [InlineData("f", SimpleTestCase, 492)]
        [InlineData("g", SimpleTestCase, 114)]
        [InlineData("h", SimpleTestCase, 65412)]
        [InlineData("i", SimpleTestCase, 65079)]
        [InlineData("x", SimpleTestCase, 123)]
        [InlineData("y", SimpleTestCase, 456)]
        public void BuildOperation(string name, string operations, UInt16 expectedOutput)
        {
            var day7 = new Day7();
            var actual = day7.Calculate(name, operations);

            Assert.Equal(expectedOutput, actual);
        }

        private const string SimpleTestCase = @"123 -> x
456 -> y
x AND y -> d
x OR y -> e
x LSHIFT 2 -> f
y RSHIFT 2 -> g
NOT x -> h
NOT y -> i";

        [Fact]
        public void Part1()
        {
            var day7 = new Day7();
            var a = day7.Calculate("a", LoadFromResource.Load(@"AdventOfCode.Tests.TestData.Day7.txt"));
            Assert.Equal(3176, a);
        }

        [Fact]
        public void Part2()
        {
            var day7 = new Day7();
            var a = day7.Calculate("a", LoadFromResource.Load(@"AdventOfCode.Tests.TestData.Day7Part2.txt"));
            Assert.Equal(14710, a);
        }
    }
}
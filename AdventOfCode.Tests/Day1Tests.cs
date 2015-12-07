using AdventOfCode.Tests.Helpers;
using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day1Tests
    {
        [Theory]
        [InlineData("(())", 0)]
        [InlineData("()()", 0)]
        [InlineData("(((", 3)]
        [InlineData("(()(()(", 3)]
        [InlineData("))(((((", 3)]
        [InlineData("())", -1)]
        [InlineData("))(", -1)]
        [InlineData(")))", -3)]
        [InlineData(")())())", -3)]
        public void FinalFloor(string descriptor, int expectedFloor)
        {
            var actual = Day1.FinalFloor(descriptor);
            Assert.Equal(expectedFloor, actual);
        }

        [Fact]
        public void FinalFloorRealData()
        {
            const int expected = 74;
            var floor = Day1.FinalFloor(LoadFromResource.Load("AdventOfCode.Tests.TestData.Day1.txt"));
            Assert.Equal(expected, floor);
        }

        [Fact]
        public void ThrowsIfNeverEntersBasement()
        {
            Assert.Throws<InvalidOperationException>(() => Day1.StepToEnterBasement("("));
        }

        [Theory]
        [InlineData(")", 1)]
        [InlineData("()())", 5)]
        public void StepToEnterBasement(string descriptor, int expectedStep)
        {
            var actual = Day1.StepToEnterBasement(descriptor);
            Assert.Equal(expectedStep, actual);
        }

        [Fact]
        public void StepsToEnterBasementRealData()
        {
            const int expected = 1795;
            var step = Day1.StepToEnterBasement(LoadFromResource.Load("AdventOfCode.Tests.TestData.Day1.txt"));
            Assert.Equal(expected, step);
        }
    }
}
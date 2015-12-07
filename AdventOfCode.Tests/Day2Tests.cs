using AdventOfCode.Tests.Helpers;
using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day2Tests    
    {
        [Theory]
        [InlineData(2, 3, 4, 34)]
        [InlineData(1, 1, 10, 14)]
        public void CalculateRibbon(int x, int y, int z, int expected)
        {
            var day2 = new Day2();
            var actual = day2.CalculateRibbonLength(new Tuple<int, int, int>(x, y, z));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2x3x4\r\n1x1x10", 48)]
        public void CalculateTotalRibbon(string input, int expected)
        {
            var day2 = new Day2();
            var actual = day2.TotalRibbon(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ActualTotalRibbon()
        {
            const int TotalRibbon = 3783758;

            var day2 = new Day2();
            var actual = day2.TotalRibbon(LoadFromResource.Load("AdventOfCode.Tests.TestData.Day2.txt"));
            Assert.Equal(TotalRibbon, actual);
        }
        
        [Theory]
        [InlineData(2, 3, 4, 58)]
        [InlineData(1, 1, 10, 43)]
        public void CalculatesCorrectSizeForSinglePresent(int x, int y, int z, int expected)
        {
            var day2 = new Day2();
            var actual = day2.CalculateArea(new Tuple<int, int, int>(x, y, z));
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> ParseTestData
        {
            get
            {
                return new[]
                {
                    new object[] { "2x3x4", new Tuple<int,int,int>(2, 3, 4) },
                    new object[] { "1x1x10", new Tuple<int,int,int>(1, 1, 10) },
                };
            }
        }

        [Theory]
        [MemberData("ParseTestData")]
        public void ParsesExampleString(string input, Tuple<int, int, int> expected)
        {
            var day2 = new Day2();
            var actual = day2.ParseStringToTuple(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2x3x4\r\n1x1x10", 101)]
        public void CalculatesTotalAreaCorrectly(string input, int expected)
        {
            var day2 = new Day2();
            var actual = day2.TotalArea(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatesRealTotalAreaCorrectly()
        {
            const int TotalArea = 1588178;

            var day2 = new Day2();
            var actual = day2.TotalArea(LoadFromResource.Load("AdventOfCode.Tests.TestData.Day2.txt"));
            Assert.Equal(TotalArea, actual);
        }

    }
}
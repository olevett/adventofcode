using AdventOfCode.Helpers;
using AdventOfCode.Tests.Helpers;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day8Tests
    {
        [Theory]
        [InlineData(@"""""", 0)]
        [InlineData(@"""abc""", 3)]
        [InlineData(@"""aaa\""aaa""", 7)]
        [InlineData(@"""\x27""", 1)]
        [InlineData(@"""\\""", 1)]
        public void CountInMemoryCharacters(string input, int expected)
        {
            var day8 = new Day8();
            var actual = day8.CountInMemoryCharacters(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CountInMemoryCharactersFromFile()
        {
            var inputs = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day8.txt");
            var line1 = inputs.SplitOnNewLines().First();

            var day8 = new Day8();
            var actual = day8.CountInMemoryCharacters(line1);

            Assert.Equal(7, actual);
        }

        [Theory]
        [InlineData(@"""""", 2)]
        [InlineData(@"""abc""", 5)]
        [InlineData("\"aaa\\\"aaa\"", 10)]
        [InlineData(@"""\x27""", 6)]
        [InlineData(@"\\", 2)]
        [InlineData(@"\""", 2)]
        public void CountCodeCharacters(string input, int expected)
        {
            var day8 = new Day8();
            var actual = day8.CountCodeCharacters(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CountCodeCharactersFromFile()
        {
            var inputs = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day8.txt");
            var line1 = inputs.SplitOnNewLines().First();

            var day8 = new Day8();
            var actual = day8.CountCodeCharacters(line1);

            Assert.Equal(9, actual);
        }

        [Fact]
        public void Part1()
        {
            var inputs = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day8.txt");
            var day8 = new Day8();
            var actual = day8.CharacterDifference(inputs);
            Assert.Equal(1350, actual);
        }
    }
}

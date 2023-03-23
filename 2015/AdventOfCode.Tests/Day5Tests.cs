using AdventOfCode.Helpers;
using AdventOfCode.Tests.Helpers;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day5Tests
    {
        [Theory]
        [InlineData("aei", true)]
        [InlineData("xazegov", true)]
        [InlineData("aeiouaeiouaeiou", true)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void CheckContainsAtLeastThreeVowels(string input, bool expectedValue)
        {
            var day5 = new Day5();
            var actual = day5.ContainsAtLeastThreeVowels(input);
            Assert.Equal(expectedValue, actual);
        }

        [Theory]
        [InlineData("aa", true)]
        [InlineData("abc", false)]
        [InlineData("dvszwmarrgswjxmb", true)]
        public void ContainsDouble(string input, bool expectedValue)
        {
            var day5 = new Day5();
            var actual = day5.ContainsDouble(input);
            Assert.Equal(expectedValue, actual);
        }

        [Theory]
        [InlineData("aa", false)]
        [InlineData("haegwjzuvuyypxyu", true)]
        public void ContainsForbiddenPairs(string input, bool expectedValue)
        {
            var day5 = new Day5();
            var actual = day5.ContainsForbiddenPairs(input);
            Assert.Equal(expectedValue, actual);
        }

        [Theory]
        [InlineData("ugknbfddgicrmopn", true)]
        [InlineData("aaa", true)]
        [InlineData("jchzalrnumimnmhp", false)]
        [InlineData("haegwjzuvuyypxyu", false)]
        [InlineData("dvszwmarrgswjxmb", false)]
        public void IsNice(string input, bool expectedValue)
        {
            var day5 = new Day5();
            var actual = day5.StringIsNice(input);
            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void NumberOfNiceStrings()
        {
            const int RealNumberOfNiceStrings = 255;
            var day5 = new Day5();

            var count = day5.NumberOfNiceStrings(LoadFromResource.Load("AdventOfCode.Tests.TestData.Day5.txt"));

            Assert.Equal(RealNumberOfNiceStrings, count);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData("qjhvhtzxzqqjkmpb", true)]
        [InlineData("xxyxx", true)]
        [InlineData("ieodomkazucvgmuy", false)]
        [InlineData("uurcxstgmygtbstg", false)]
        public void IsNice2(string input, bool expectedValue)
        {
            var day5 = new Day5();
            var actual = day5.IsNice2(input);
            Assert.Equal(expectedValue, actual);
        }

        [Fact]
        public void NumberOfNiceStrings2()
        {
            const int RealNumberOfNiceStrings = 55;
            var day5 = new Day5();
            var count = day5.NumberOfNiceStrings2(LoadFromResource.Load("AdventOfCode.Tests.TestData.Day5.txt"));
            Assert.Equal(RealNumberOfNiceStrings, count);
        }
    }
}
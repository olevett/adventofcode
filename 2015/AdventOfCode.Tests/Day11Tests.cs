using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day11Tests
    {
        [Theory]
        [InlineData("abc", true)]
        [InlineData("hijklmmn", true)]
        [InlineData("abbceffg", false)]
        public void ContainsStraight(string input, bool expected)
        {
            var day11 = new Day11();
            var actual = day11.ContainsStraight(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abc", false)]
        [InlineData("hijklmmn", true)]
        public void ContainsForbiddenCharacters(string input, bool expected)
        {
            var day11 = new Day11();
            var actual = day11.ContainsForbiddenCharacters(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abbceffg", true)]
        [InlineData("abcdffaa", true)]
        [InlineData("ghijklmn", false)]
        [InlineData("ghjaabcc", true)]
        public void ContainsTwoNoOverlappingPairs(string input, bool expected)
        {
            var day11 = new Day11();
            var actual = day11.ContainsTwoNoOverlappingPairs(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abbceffg", false)]
        [InlineData("hijklmmn", false)]
        [InlineData("abbcegjk", false)]
        [InlineData("abcdefgh", false)]
        [InlineData("abcdffaa", true)]
        [InlineData("ghijklmn", false)]
        [InlineData("ghjaabcc", true)]
        public void PasswordIsValid(string input, bool expected)
        {
            var day11 = new Day11();
            var actual = day11.PasswordIsValid(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abcdefgh", "abcdffaa")]
        [InlineData("ghijklmn", "ghjaabcc")]
        public void FindNextPassword(string input, string expected)
        {
            var day11 = new Day11();
            var actual = day11.FindNextPassword(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("a", 0)]
        [InlineData("b", 1)]
        [InlineData("ba", 26)]
        public void ConvertToInt(string input, ulong expectedOutput)
        {
            Assert.Equal(expectedOutput, Day11.ConvertToInt(input));
        }

        [Theory]
        [InlineData(0, "a")]
        [InlineData(26, "ba")]
        public void ConvertToString(ulong input, string expectedOutput)
        {
            Assert.Equal(expectedOutput, Day11.ConvertToString(input));
        }


        [Fact]
        public void FindNextPasswordPart1()
        {
            const string currentPassword = "vzbxkghb";
            var day11 = new Day11();
            var nextPassword = day11.FindNextPassword(currentPassword);

            Assert.Equal("vzbxxyzz", nextPassword);
        }

        [Fact]
        public void FindNextPasswordPart2()
        {
            const string currentPassword = "vzbxkghb";
            var day11 = new Day11();
            var interimPassword = day11.FindNextPassword(currentPassword);
            var finalPassword = day11.FindNextPassword(interimPassword);

            Assert.Equal("vzcaabcc", finalPassword);
        }
    }
}

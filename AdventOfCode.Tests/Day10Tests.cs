using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day10Tests
    {
        [Theory]
        [InlineData("1", "11")]
        [InlineData("11", "21")]
        [InlineData("222", "32")]
        [InlineData("1211", "111221")]
        [InlineData("111221", "312211")]
        [InlineData("2", "12")]
        public void LookAndSee(string input, string expected)
        {
            var day10 = new Day10();
            var actual = day10.LookAndSay(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1",1 ,"11")]
        [InlineData("1", 2, "21")]
        [InlineData("1", 3, "1211")]
        [InlineData("1",4, "111221")]
        [InlineData("1",5 ,"312211")]
        public void LookAndSeeMultiple(string input, int repetitions, string expected)
        {
            var day10 = new Day10();
            var actual = day10.LookAndSay(input, repetitions);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void LookAndSayActual()
        {
            const int TotalRibbon = 492982;

            var day10 = new Day10();
            var actual = day10.LookAndSay("1321131112", 40);

            Assert.Equal(TotalRibbon, actual.Length);
        }


        [Fact]
        public void LookAndSayActualPart2()
        {
            const int TotalRibbon = 6989950;

            var day10 = new Day10();
            var actual = day10.LookAndSay("1321131112", 50);

            Assert.Equal(TotalRibbon, actual.Length);
        }
    }
}

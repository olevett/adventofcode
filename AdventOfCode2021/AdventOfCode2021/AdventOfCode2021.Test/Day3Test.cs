using Xunit;

namespace AdventOfCode2021.Test
{
    public class Day3Test
    {
        [Fact]
        public void Day3Part1Practice()
        {
            var input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            var sut = new Day3();
            var actual = sut.Part1(input);

            Assert.Equal("198", actual);
        }

        [Fact]
        public void Day3Part2Practice()
        {
            var input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
            var sut = new Day3();
            var actual = sut.Part2(input);

            Assert.Equal("230", actual);
        }
    }
}

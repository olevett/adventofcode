using Xunit;

namespace AdventOfCode2021.Test
{
    public class Day2Test
    {
        [Fact]
        public void Day2Part1Practice()
        {
            var input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            var sut = new Day2();
            var actual = sut.Part1(input);

            Assert.Equal("150", actual);
        }

        [Fact]
        public void Day2Part2Practice()
        {
            var input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";
            var sut = new Day2();
            var actual = sut.Part2(input);

            Assert.Equal("900", actual);
        }
    }
}

using Xunit;

namespace AdventOfCode2021.Test
{
    public class Day1Test
    {
        [Fact]
        public void Day1Part1Practice()
        {
            var input = "199\r\n" +
                 "200\r\n" +
                 "208\r\n" +
                 "210\r\n" +
                 "200\r\n" +
                 "207\r\n" +
                 "240\r\n" +
                 "269\r\n" +
                 "260\r\n" +
                 "263";
            var sut = new Day1();
            var actual = sut.Part1(input);

            Assert.Equal("7", actual);
        }

        [Fact]
        public void Day1Part2Practice()
        {
            var input = "199\r\n" +
                 "200\r\n" +
                 "208\r\n" +
                 "210\r\n" +
                 "200\r\n" +
                 "207\r\n" +
                 "240\r\n" +
                 "269\r\n" +
                 "260\r\n" +
                 "263";
            var sut = new Day1();
            var actual = sut.Part2(input);

            Assert.Equal("5", actual);
        }
    }
}
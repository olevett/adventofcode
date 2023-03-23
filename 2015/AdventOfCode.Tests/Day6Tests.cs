using AdventOfCode.Tests.Helpers;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day6Tests
    {
        [Theory]
        [InlineData("toggle 0,0 through 999,0", 1000)]
        [InlineData("turn on 0,0 through 2,2", 9)]
        [InlineData("turn off 0,0 through 2,2", 0)]
        [InlineData("turn on 0,0 through 2,2\r\nturn off 0,0 through 2,2", 0)]
        [InlineData("turn on 0,0 through 2,2\r\ntoggle 0,0 through 2,2", 0)]
        public void TotalTurnedOn(string input, int expectedOn)
        {
            var day6 = new Day6();
            var actual = day6.TotalTurnedOn(input);
            Assert.Equal(expectedOn, actual);
        }

        [Fact]
        public void TotalTurnedOnActual()
        {
            var input = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day6.txt");
            const int expected = 543903;
            var day6 = new Day6();

            var actual = day6.TotalTurnedOn(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("toggle 0,0 through 999,0", 2000)]
        [InlineData("turn on 0,0 through 2,2", 9)]
        [InlineData("turn off 0,0 through 2,2", 0)]
        [InlineData("turn on 0,0 through 2,2\r\nturn off 0,0 through 2,2", 0)]
        [InlineData("turn on 0,0 through 2,2\r\ntoggle 0,0 through 2,2", 27)]
        public void TotalBrightness(string input, int expectedOn)
        {
            var day6 = new Day6();
            var actual = day6.TotalBrightness(input);
            Assert.Equal(expectedOn, actual);
        }

        [Fact]
        public void TotalBrightnessActual()
        {
            var input = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day6.txt");
            const int expected = 14687245; 
            var day6 = new Day6();

            var actual = day6.TotalBrightness(input);

            Assert.Equal(expected, actual);
        }
    }
}

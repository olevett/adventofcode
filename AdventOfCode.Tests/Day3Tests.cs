using AdventOfCode.Tests.Helpers;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day3Tests
    {
        [Theory]
        [InlineData(">", 2)]
        [InlineData("^>v<", 4)]
        [InlineData("^v^v^v^v^v", 2)]
        public void CalculatesExpectedHousesCorrectly(string route, int expectedHouses)
        {
            var day3 = new Day3();
            var actual = day3.CalculateHouseVisits(route);
            Assert.Equal(expectedHouses, actual);
        }

        [Fact]
        public void ActualHouseVisits()
        {
            const int expected = 2592;
            var day3 = new Day3();
            var actual = day3.CalculateHouseVisits(LoadFromResource.Load("AdventOfCode.Tests.TestData.Day3.txt"));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("^v", 3)]
        [InlineData("^>v<", 3)]
        [InlineData("^v^v^v^v^v", 11)]
        public void CalculatesExpectedHousesForRoboSanta(string route, int expectedHouses)
        {
            var day3 = new Day3();
            var actual = day3.CalculateRoboSantaHouseVisits(route);
            Assert.Equal(expectedHouses, actual);
        }

        [Fact]
        public void RoboSantaActual()
        {
            const int expected = 2360;
            var day3 = new Day3();
            var actual = day3.CalculateRoboSantaHouseVisits(LoadFromResource.Load("AdventOfCode.Tests.TestData.Day3.txt"));
            Assert.Equal(expected, actual);
        }
    }
}

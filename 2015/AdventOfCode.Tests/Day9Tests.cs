using AdventOfCode.Helpers;
using AdventOfCode.Tests.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day9Tests
    {
        [Theory]
        [InlineData("London to Dublin = 464", new[] { "London", "Dublin" })]
        [InlineData("London to Dublin = 464\r\nLondon to Belfast = 518\r\nDublin to Belfast = 141", new[] { "London", "Dublin", "Belfast" })]
        public void SplitsCityNames(string input, IEnumerable<string> expectedNames)
        {
            var day9 = new Day9();
            var actualNames = day9.GetCityNames(input.SplitOnNewLines());
            Assert.Equal(expectedNames.Count(), actualNames.Count());
            foreach (var name in expectedNames)
            {
                Assert.Contains(name, actualNames);
            }
        }

        [Theory]
        [InlineData( "London to Dublin = 464", "London", "Dublin", 464)]
        public void GetCityToCityDistance(string cityLine, string name, string secondCity, int distance)
        {
            var day9 = new Day9();
            var actual = day9.GetCityToCityDistance(cityLine);
            
            Assert.Equal(name, actual.Key.Item1);
            Assert.Equal(secondCity, actual.Key.Item2);
            Assert.Equal(distance, actual.Value);
        }

        [Theory]
        [InlineData("London to Dublin = 464\r\nLondon to Belfast = 518\r\nDublin to Belfast = 141", 605)]
        public void CalculatesShortestDistance(string citys, int expected)
        {
            var day9 = new Day9();
            var actual = day9.GetShortestDistance(citys);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatesShortestDistanceForRealData()
        {
            const int expected = 251;
            var data = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day9.txt");
            var day9 = new Day9();
            var actual = day9.GetShortestDistance(data);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("London to Dublin = 464\r\nLondon to Belfast = 518\r\nDublin to Belfast = 141", 982)]
        public void CalculatesLongestDistance(string citys, int expected)
        {
            var day9 = new Day9();
            var actual = day9.GetLongestDistance(citys);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculatesLongestDistanceForRealData()
        {
            const int expected = 898;
            var data = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day9.txt");
            var day9 = new Day9();
            var actual = day9.GetLongestDistance(data);

            Assert.Equal(expected, actual);
        }
    }
}

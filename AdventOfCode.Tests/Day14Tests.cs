using AdventOfCode.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day14Tests
    {
        [Theory]
        [InlineData("Vixen can fly 8 km/s for 8 seconds, but then must rest for 53 seconds.", "Vixen", 8, 8, 53)]
        public void ParseReindeerCorrectly(string input, string name, int speed, int flightTime, int restTime)
        {
            var day14 = new Day14();
            var reindeer = day14.GenerateFromString(input);

            Assert.Equal(name, reindeer.Name);
            Assert.Equal(speed, reindeer.Speed);
            Assert.Equal(flightTime, reindeer.FlightTime);
            Assert.Equal(restTime, reindeer.RestTime);
        }

        [Theory]
        [InlineData("Comet", 14, 10, 127, 1, 14)]
        [InlineData("Comet", 14, 10, 127, 10, 140)]
        [InlineData("Comet", 14, 10, 127, 11, 140)]
        [InlineData("Comet", 14, 10, 127, 1000, 1120)]
        [InlineData("Dancer", 16, 11, 162, 10, 160)]
        [InlineData("Dancer", 16, 11, 162, 11, 176)]
        public void DistanceAfterTime(string name, int speed, int flightTime, int restTime, int time, int expectedDistance)
        {
            var day14 = new Day14();
            var reindeer = new Reindeer { Name = name, Speed = speed, FlightTime = flightTime, RestTime = restTime };

            var actualDistance = day14.DistanceAfterTime(reindeer, time);

            Assert.Equal(expectedDistance, actualDistance);
        }

        [Theory]
        [InlineData("Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.\r\nDancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.", 1000, 1120)]
        public void DistanceTravelledByFurthestReindeer(string reindeer, int time, int expectedDistance)
        {
            var day14 = new Day14();
           var actualDistance = day14.DistanceTravelledByFurthestReindeer(reindeer, time);

           Assert.Equal(expectedDistance, actualDistance);
        }

        [Fact]
        public void DistanceTravelledByFurthestReindeerPart1()
        {
            var day14 = new Day14();
            const int time = 2503;
            const int expectedDistance = 2655;

            var data = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day14.txt");

            var actualDistance = day14.DistanceTravelledByFurthestReindeer(data, time);

            Assert.Equal(expectedDistance, actualDistance);
        }


        [Theory]
        [InlineData("Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.\r\nDancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.", 1000, 689)]
        public void PointsOfWinningReindeer(string reindeer, int time, int expectedDistance)
        {
            var day14 = new Day14();
            var actualDistance = day14.CalculateScoreForWinningReindeer(reindeer, time);

            Assert.Equal(expectedDistance, actualDistance);
        }

        [Fact]
        public void PointsOfWinningReindeerActual()
        {
            var day14 = new Day14();
            const int time = 2503;
            const int expectedPoints = 1059;

            var data = LoadFromResource.Load("AdventOfCode.Tests.TestData.Day14.txt");

            var actualDistance = day14.CalculateScoreForWinningReindeer(data, time);

            Assert.Equal(expectedPoints, actualDistance);
        }
    }
}

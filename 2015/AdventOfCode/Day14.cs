using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Helpers;

namespace AdventOfCode
{
    public class Day14
    {
        private readonly Regex reindeerRegex = new Regex(@"(\w+) can fly (\d+) km/s for (\d+) seconds, but then must rest for (\d+) seconds.");

        public double DistanceTravelledByFurthestReindeer(string reindeerDescriptor, int time)
        {
            return reindeerDescriptor.SplitOnNewLines().Select(GenerateFromString).Select(r => DistanceAfterTime(r, time)).Max();
        }

        public Reindeer GenerateFromString(string descriptor)
        {
            var matches = reindeerRegex.Match(descriptor);
            return new Reindeer
            {
                Name = matches.Groups[1].Value,
                Speed = int.Parse(matches.Groups[2].Value),
                FlightTime = int.Parse(matches.Groups[3].Value),
                RestTime = int.Parse(matches.Groups[4].Value)
            };
        }

        public int DistanceAfterTime(Reindeer reindeer, int time)
        {
            var totalCycleTime = reindeer.FlightTime + reindeer.RestTime;

            var fullCyleTime = (reindeer.FlightTime * (time / totalCycleTime));
            var partialCycleTime = (int)Math.Min(reindeer.FlightTime, (double)(time % totalCycleTime));

            return (fullCyleTime + partialCycleTime) * reindeer.Speed;
        }

        public int CalculateScoreForWinningReindeer(string input, int time)
        {
            var reindeer = input.SplitOnNewLines().Select(GenerateFromString).ToDictionary(r => r, _ => 0);

            for (var i = 1; i <= time; i++)
            {
                var reindeerDistances = reindeer.Keys.ToDictionary(r => r, r => DistanceAfterTime(r, i));
                var winners = reindeerDistances.Where(x => x.Value == reindeerDistances.Values.Max());
                foreach (var winner in winners)
                {
                    reindeer.AddOrUpdate(winner.Key, 1, (_, score) => score + 1);
                }
            }
            return reindeer.Values.Max();
        }
    }

    public class Reindeer
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int FlightTime { get; set; }
        public int RestTime { get; set; }
    }
}
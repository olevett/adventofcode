using AdventOfCode.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day9
    {
        private readonly Regex CityToCityDistanceRegex = new Regex(@"(\w+) to (\w+) = (\d+)");

        public int GetShortestDistance(string input)
        {
            return GetDistances(input).Select(x => x.Value).OrderBy(x => x).First();
        }

        public int GetLongestDistance(string input)
        {
            return GetDistances(input).Select(x => x.Value).OrderByDescending(x => x).First();
        }

        public IDictionary<IEnumerable<string>, int> GetDistances(string input)
        {
            var cityLinks = input.SplitOnNewLines();
            var cityNames = GetCityNames(cityLinks);
            var cityToCityDistances = GetCityToCityDistances(cityLinks);
            var permuations = cityNames.GetPermutations();
            return permuations.ToDictionary(x => x, x => CalculatePermutationLength(x, cityToCityDistances));
        }

        public IEnumerable<string> GetCityNames(IEnumerable<string> cityLinks)
        {
            return cityLinks.SelectMany(GetCityNamesFromLine).Distinct();
        }

        public IDictionary<Tuple<string, string>, int> GetCityToCityDistances(IEnumerable<string> cityLinks)
        {
            return cityLinks.Select(GetCityToCityDistance).ToDictionary(x => x.Key, x => x.Value);
        }

        private int CalculatePermutationLength(IEnumerable<string> route, IDictionary<Tuple<string, string>, int> cityToCityDistances)
        {
            var routeArray = route.ToArray();
            var distance = 0;
            for (var i = 0; i < routeArray.Length - 1; i++)
            {
                var cityName1 = routeArray[i];
                var cityName2 = routeArray[i + 1];

                distance += cityToCityDistances.Single(x =>
                    (x.Key.Item1 == cityName1 && x.Key.Item2 == cityName2)
                    || (x.Key.Item1 == cityName2 && x.Key.Item2 == cityName1)).Value;
            }
            return distance;
        }

        public KeyValuePair<Tuple<string, string>, int> GetCityToCityDistance(string input)
        {
            var matches = CityToCityDistanceRegex.Match(input);

            return new KeyValuePair<Tuple<string, string>, int>(
                new Tuple<string, string>(matches.Groups[1].Value, matches.Groups[2].Value),
                int.Parse(matches.Groups[3].Value));
        }

        private static IEnumerable<string> GetCityNamesFromLine(string input)
        {
            var split = input.Split(' ');
            return new[] { split[0], split[2] };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public  class Day2
    {
        public int TotalArea(string input)
        {
            return SplitOnNewLines(input).Select(ParseStringToTuple).Sum(x => CalculateArea(x));
        }

        public int CalculateArea(Tuple<int, int, int> input)
        {
            var faceAreas = new List<int>();
            faceAreas.Add(input.Item1 * input.Item2);
            faceAreas.Add(input.Item2 * input.Item3);
            faceAreas.Add(input.Item3 * input.Item1);

            return faceAreas.Sum(a => a * 2) + faceAreas.OrderBy(x => x).First();
        }

        public int TotalRibbon(string input)
        {
            return SplitOnNewLines(input).Select(ParseStringToTuple).Sum(x => CalculateRibbonLength(x));
        }

        public int CalculateRibbonLength(Tuple<int, int, int> input)
        {
            var volume = input.Item1 * input.Item2 * input.Item3;

            var facePerimeters = new List<int>();
            facePerimeters.Add(2 * (input.Item1 + input.Item2));
            facePerimeters.Add(2 * (input.Item2 + input.Item3));
            facePerimeters.Add(2 * (input.Item3 + input.Item1));

            return facePerimeters.OrderBy(x => x).First() + volume;
        }

        public Tuple<int, int, int> ParseStringToTuple(string input)
        {
            var vals = input.Split('x').Select(int.Parse).ToList();
            return new Tuple<int, int, int>(vals[0], vals[1], vals[2]);
        }

        public IEnumerable<string> SplitOnNewLines(string input)
        {
            return input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }
    }
}

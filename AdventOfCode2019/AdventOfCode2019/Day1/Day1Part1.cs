using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day1
{
    public class Day1Part1
    {
        public int Process(IEnumerable<string> input)
        {

            return input.Select(int.Parse).Select(FuelForModule).Sum();
                    }

        public int FuelForModule(int mass)
        {
            return (mass / 3) - 2;
        }
    }
}

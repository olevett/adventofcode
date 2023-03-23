using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Day1
{
    public class Day1Part2
    {
        public int Process(IEnumerable<string> input)
        {
            return input.Select(int.Parse).Select(FuelForModule).Sum();
        }

        public int FuelForModule(int mass)
        {
            int fuelMass = (mass / 3) - 2;
            if(fuelMass > 0)
            {
                return FuelForModule(fuelMass) + fuelMass;
            }
            return 0;
        }
    }
}

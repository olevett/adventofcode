using System.Linq;

namespace AdventOfCode2018CS.Q1
{
    public class Part1
    {
        public int CalculateFrequency(string input)
        {
            return input
                .SplitOnNewLines()
                .Select(int.Parse)
                .Sum();
        }
    }
}

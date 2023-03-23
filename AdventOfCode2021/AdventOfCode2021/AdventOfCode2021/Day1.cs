using MoreLinq;

namespace AdventOfCode2021
{
    public class Day1 : Day
    {
        public string Part1Expected => "1766";

        public string Part2Expected => "1797";

        public string Part1(string input)
        {
            return Day1Calculation(input, 1);
        }

        public string Part2(string input)
        {
            return Day1Calculation(input, 3);
        }

        private static string Day1Calculation(string input, int windowSize)
        {
            return input
                  .Split(Environment.NewLine)
                  .Select(x => int.Parse(x))
                  .Window(windowSize)
                  .Select(x => x.Sum())
                  .Aggregate(new
                  {
                      Previous = (int?)null,
                      StepsUp = 0,
                  }, (accumulator, current) =>
                  {
                      if (accumulator.Previous == null)
                      {
                          return new
                          {
                              Previous = (int?)current,
                              StepsUp = 0
                          };
                      }
                      return new
                      {
                          Previous = (int?)current,
                          StepsUp = current > accumulator.Previous ? accumulator.StepsUp + 1 : accumulator.StepsUp,
                      };
                  }).StepsUp.ToString();
        }
    }
}

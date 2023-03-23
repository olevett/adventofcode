using System;
using System.Linq;

namespace AdventOfCode
{
    public static class Day1
    {
        private const char IncreaseFloor = '(';
        private const char DecreaseFloor = ')';

        public static int FinalFloor(string route)
        {
            var floorsUp = route.Count(c => c == IncreaseFloor);
            var floorsDown = route.Count(c => c == DecreaseFloor);
            return floorsUp - floorsDown;
        }

        public static int StepToEnterBasement(string route)
        {
            var floor = 0;
            var step = 1;

            foreach (var x in route)
            {
                switch (x)
                {
                    case IncreaseFloor:
                        floor++;
                        break;
                    case DecreaseFloor:
                        floor--;
                        break;
                }
                if (floor < 0) return step;
                step++;
            }

            throw new InvalidOperationException("Never enters basement");
        }
    }
}

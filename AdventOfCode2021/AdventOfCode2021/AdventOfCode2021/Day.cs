namespace AdventOfCode2021
{
    public interface Day
    {
        public string Part1(string input);
        public string Part2(string input);

        public string Part1Expected { get; }
        public string Part2Expected { get; }

    }
}

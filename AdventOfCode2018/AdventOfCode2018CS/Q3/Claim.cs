using System.Text.RegularExpressions;

namespace AdventOfCode2018CS.Q3
{
    public class Claim
    {
        public int Id { get; }
        public int Left { get; }
        public int Top { get; }
        public int Width { get; }
        public int Height { get; }

        private Claim(int id, int left, int top, int width, int height)
        {
            Id = id;
            Left = left;
            Top = top;
            Width = width;
            Height = height;
        }

        public static Claim Parse(string input)
        {
            var match = Regex.Matches(input, @"#(\d+) @ (\d+),(\d+): (\d+)x(\d+)")[0];
            return new Claim(
                int.Parse(match.Groups[1].Value),
                int.Parse(match.Groups[2].Value),
                int.Parse(match.Groups[3].Value),
                int.Parse(match.Groups[4].Value),
                int.Parse(match.Groups[5].Value)
            );
        }
    }
}

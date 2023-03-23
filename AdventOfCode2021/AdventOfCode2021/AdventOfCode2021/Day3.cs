namespace AdventOfCode2021
{
    public class Day3 : Day
    {
        public string Part1Expected => "";

        public string Part2Expected => "";

        public string Part1(string input)
        {
            var lines = input.Split(Environment.NewLine);
            var bitLength = lines.First().Length;

            var bitCount = lines.Aggregate(new int[bitLength], (accumulator, x) => x.Zip(accumulator, (a, b) => a == '1' ? b + 1 : b).ToArray());

            var winningDigit = bitCount.Select(x => {
               
                return x > lines.Count() / 2 ? 1 : 0;

            }).ToArray();

            var gamma = winningDigit.Select((item, index) => new { item, index }).Aggregate(0, (accumulator, x) =>
            {
                return (accumulator | x.item << (bitLength - x.index -1));
                });

            var epsilon = winningDigit.Select((item, index) => new { item, index }).Aggregate(0, (accumulator, x) =>
            {
                return (accumulator | (1^x.item) << (bitLength - x.index - 1));
            });
            return (gamma * epsilon).ToString();
        }


        public string Part2(string input)
        {
            var lines = input.Split(Environment.NewLine);
            return (Extract2(lines, MostCommonBitAt) * Extract2(lines, LeastCommonBitAt)).ToString();        
        }

        char MostCommonBitAt(string[] lines, int ibit) =>
        2 * lines.Count(line => line[ibit] == '1') >= lines.Length ? '1' : '0';

        char LeastCommonBitAt(string[] lines, int ibit) =>
            MostCommonBitAt(lines, ibit) == '1' ? '0' : '1';

 

        int Extract2(string[] lines, Func<string[], int, char> selectBitAt)
        {
            var cbit = lines[0].Length;

            for (var ibit = 0; lines.Length > 1 && ibit < cbit; ibit++)
            {
                var bit = selectBitAt(lines, ibit);
                lines = lines.Where(line => line[ibit] == bit).ToArray();
            }

            return Convert.ToInt32(lines[0], 2);
        }
    }
}

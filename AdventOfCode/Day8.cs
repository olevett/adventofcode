using AdventOfCode.Helpers;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day8
    {
        private Regex hexRegex = new Regex("([\\][x][0-9a-f][0-9a-f])");

        public int CountInMemoryCharacters(string input)
        {
            input = input.Replace("\\\"", "A");            
            
            var count = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (input[i] == '\\')
                {
                    if (input[i + 1] == 'x')
                    {
                        i += 3;
                    }
                    else if (input[i + 1] == '\\')
                    {
                        i += 1;
                    }
                    else if (input[i + 1] == '\"')
                    {
                        i += 1;
                    }
                }
                count++;
            }
            return count-2;
        }

        public int CountCodeCharacters(string input)
        {
            return input.Length;
        }

        public int CharacterDifference(string input)
        {
            var totalInMemory = input.SplitOnNewLines().Select(CountInMemoryCharacters).Sum();
            var totalCode = input.SplitOnNewLines().Select(CountCodeCharacters).Sum(); 
            return totalCode - totalInMemory;
        }
    }
}

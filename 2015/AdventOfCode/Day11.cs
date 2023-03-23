using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day11
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string ForbiddenCharacters = "iol";
        private Regex twoPairsRegex = new Regex(@"(\w)\1\w*(\w)\2");

        public bool ContainsStraight(string input)
        {
            var triplets = new List<string>();
            for (var i = 0; i < 24; i++)
            {
                triplets.Add(Alphabet.Substring(i, 3));
            }

            return triplets.Any(x => input.Contains(x));
        }

        public bool ContainsForbiddenCharacters(string input)
        {
            return ForbiddenCharacters.Any(x => input.Contains(x));
        }

        public bool ContainsTwoNoOverlappingPairs(string input)
        {
            return twoPairsRegex.IsMatch(input);
        }

        public bool PasswordIsValid(string input)
        {
            return ContainsStraight(input) && !ContainsForbiddenCharacters(input) && ContainsTwoNoOverlappingPairs(input);
        }

        public string FindNextPassword(string input)
        {
            var passwordValue = ConvertToInt(input);
            var newPassword = "";
            do
            {
                newPassword = ConvertToString(++passwordValue);
            } 
            while (!PasswordIsValid(newPassword));

            return newPassword.PadLeft(input.Length, 'a'); ;
        }

        public static ulong ConvertToInt(string input)
        {
            var reverse = input.Reverse().ToArray();
            ulong accumlator = 0;
            for (var i = 0; i < input.Length; i++)
            {
                accumlator += (ulong)((reverse[i] - 97) * Math.Pow(26, i));
            }
            return accumlator;
        }

        public static string ConvertToString(ulong input)
        {
            var output = "";
            do
            {
                var modulo = (input) % 26;
                output = Convert.ToChar(97 + modulo).ToString() + output;
                input = (ulong)((input) / 26);
            }
            while (input > 0);

            return output;
        }
    }
}

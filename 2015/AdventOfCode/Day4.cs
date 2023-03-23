using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode
{
    public class Day4
    {
        private readonly HashAlgorithm hashAlgorithm;

        public Day4()
        {
            hashAlgorithm = MD5.Create();
        }

        public int CalculateKey(string input)
        {
            var key = 0;
            while (true)
            {
                var check = string.Format("{0}{1}", input, key);
                if (MD5MatchesZeros(check)) return key;
                key++;
            }
        }

        private bool MD5MatchesZeros(string input)
        {
            var hashBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));            
            return hashBytes[0] == 0 && hashBytes[1] == 0 && hashBytes[2] < 0x0F;
        }

        public int CalculateKeySixZeros(string input)
        {
            var key = 0;
            while (true)
            {
                var check = string.Format("{0}{1}", input, key);
                if (MD5MatchesSixZeros(check)) return key;
                key++;
            }
        }

        private bool MD5MatchesSixZeros(string input)
        {
            var hashBytes = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            return hashBytes[0] == 0 && hashBytes[1] == 0 && hashBytes[2] == 0;
        }
    }
}

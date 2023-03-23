using AdventOfCode2018CS.Q2;
using System.IO;
using System.Reflection;
using Xunit;

namespace AdventOfCode2018CS.Tests.Q2
{
    public class Part1Tests
    {
        [Theory]
        [InlineData("abcdef", false, false)]
        [InlineData("bababc", true, true)]
        [InlineData("abbcde", true, false)]
        [InlineData("abcccd", false, true)]
        [InlineData("aabcdd", true, false)]
        [InlineData("abcdee", true, false)]
        [InlineData("ababab", false, true)]
        public void CalculatesIntermediate(string input, bool hasDouble, bool hasTriple)
        {
            var actual = input.CountDoublesAndTriples();

            Assert.Equal(hasDouble, actual.HasDouble);
            Assert.Equal(hasTriple, actual.HasTriple);
        }


        [Theory]
        [InlineData(@"abcdef
bababc
abbcde
abcccd
aabcdd
abcdee
ababab",12)]
        public void CalculatesChecksum(string input, int checksum)
        {
            var actual = input.CalculateChecksum();

            Assert.Equal(checksum, actual);
        }

        [Fact]
        public void Actual()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AdventOfCode2018CS.Tests.Q2.Sample.txt";

            string result = "";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            
            var actual = result.CalculateChecksum();

            Assert.Equal(4693, actual);
        }
    }
}

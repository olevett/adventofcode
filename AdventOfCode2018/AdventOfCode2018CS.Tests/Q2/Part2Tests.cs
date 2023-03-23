using AdventOfCode2018CS.Q2;
using System.IO;
using System.Reflection;
using Xunit;

namespace AdventOfCode2018CS.Tests.Q2
{
    public class Part2Tests
    {
        [Theory]
        [InlineData(@"abcde
fghij
klmno
pqrst
fguij
axcye
wvxyz", "fgij")]
        [InlineData(@"cat
dog
dig", "dg")]
        public void CalculatesIntermediate(string input, string expected)
        {
            var actual = input.CommonBetween();

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("abc","abd", true)]
        public void OneCharacterDifferent(string x, string y, bool expected)
        {
            var actual = Part2.OneCharacterDifferent(x, y);
            Assert.Equal(expected, actual);
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

            var actual = result.CommonBetween();

            Assert.Equal("pebjqsalrdnckzfihvtxysomg", actual);
        }
    }
}

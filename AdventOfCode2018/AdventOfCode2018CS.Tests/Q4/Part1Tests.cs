using AdventOfCode2018CS.Q3;
using System.IO;
using System.Reflection;
using Xunit;

namespace AdventOfCode2018CS.Tests.Q4
{
    public class Part1Tests
    {
        [Theory]
        [InlineData("#123 @ 3,2: 5x4", 0)]
        [InlineData("#123 @ 3,2: 5x4\r\n#123 @ 3,2: 5x4", 20)]
        public void CalculateNumberOfDoublyClaimedSquares(string input, int expected)
        {
            var actual = input.CalculateNumberOfDoublyClaimedSquares();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Actual()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AdventOfCode2018CS.Tests.Q3.Sample.txt";

            string result = "";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            var actual = result.CalculateNumberOfDoublyClaimedSquares();

            Assert.Equal(119572, actual);
        }

        [Fact]
        public void ActualPart2()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AdventOfCode2018CS.Tests.Q3.Sample.txt";

            string result = "";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            var actual = result.IdOfNonOverlappingClaim();

            Assert.Equal(775, actual);
        }
    }
}

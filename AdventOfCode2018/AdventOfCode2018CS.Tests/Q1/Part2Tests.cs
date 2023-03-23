using AdventOfCode2018CS.Q1;
using System.IO;
using System.Reflection;
using Xunit;

namespace AdventOfCode2018CS.Tests.Q1
{
    public class Part2Tests
    {
        [Theory]
        [InlineData("+1, -1",0)]
        [InlineData("+3, +3, +4, -2, -4", 10)]
        [InlineData("-6, +3, +8, +5, -6", 5)]
        [InlineData("+7, +7, -2, -7, -4", 14)]
        public void SampleTests(string input, int expected)
        {
            var sut = new Part2();
            var actual = sut.CalculateFirstDuplicate(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Actual()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AdventOfCode2018CS.Tests.Q1.Sample.txt";

            string result = "";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            var sut = new Part2();
            var actual = sut.CalculateFirstDuplicate(result);

            Assert.Equal(66932, actual);
        }
    }
}

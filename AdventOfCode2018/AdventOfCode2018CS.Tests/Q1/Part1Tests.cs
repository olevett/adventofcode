using AdventOfCode2018CS.Q1;
using System.IO;
using System.Reflection;
using Xunit;

namespace AdventOfCode2018CS.Tests.Q1
{
    public class Part1Tests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData(@"+1
+1
+1", 3)]
        [InlineData(@"+1
+1
-2", 0)]
        [InlineData(@"-1
-2
-3", -6)]
        public void SampleTests(string input, int expected)
        {
            var sut = new Part1();
            var actual = sut.CalculateFrequency(input);
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

            var sut = new Part1();
            var actual = sut.CalculateFrequency(result);

            Assert.Equal(472, actual);
        }
    }
}

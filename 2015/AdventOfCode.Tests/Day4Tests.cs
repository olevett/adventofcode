using Xunit;

namespace AdventOfCode.Tests
{
    public class Day4Tests
    {
        private const string SecretKey = "yzbqklnj";
        private const int ActualAnswer = 282749;
        private const int ActualAnswerForSixZeros = 9962624;

        [Theory]
        [InlineData("abcdef", 609043)]
        [InlineData("pqrstuv", 1048970)]
        public void GetsCorrectKey(string secret, int expectedAnswer)
        {
            var day4 = new Day4();
            var actual = day4.CalculateKey(secret);
            Assert.Equal(expectedAnswer, actual);
        }

        [Fact]
        public void GetsCorrectKeyForActual()
        {
            var day4 = new Day4();
            var actual = day4.CalculateKey(SecretKey);
            Assert.Equal(ActualAnswer, actual);
        }

        [Fact]
        public void GetsCorrectKeyForSixZeros()
        {
            var day4 = new Day4();
            var actual = day4.CalculateKeySixZeros(SecretKey);
            Assert.Equal(ActualAnswerForSixZeros, actual);
        }
    }
}

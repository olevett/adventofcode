using AdventOfCode2018CS.Q3;
using Xunit;

namespace AdventOfCode2018CS.Tests.Q3
{
    public class ClaimTests
    {
        [Theory]
        [InlineData("#123 @ 3,2: 5x4", 123, 3, 2, 5, 4)]
        public void ParsesExpectedClaim(string input, int id, int left, int top, int width, int height)
        {
            var claim = Claim.Parse(input);

            Assert.Equal(id, claim.Id);
            Assert.Equal(left, claim.Left);
            Assert.Equal(top, claim.Top);
            Assert.Equal(width, claim.Width);
            Assert.Equal(height, claim.Height);
        }
    }
}

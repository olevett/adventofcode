using AdventOfCode2018CS.Q3;
using Xunit;

namespace AdventOfCode2018CS.Tests.Q3
{
    public class FabricTests
    {
        [Theory]
        [InlineData("#123 @ 3,2: 5x4", 20)]
        public void FabricRecordsSingleClaim(string input, int numberOfClaimedSquares)
        {
            var fabric = new Fabric();
            fabric.MakeClaim(Claim.Parse(input));
            Assert.Equal(numberOfClaimedSquares, fabric.NumberOfClaimedSquares());
            
        }

        [Theory]
        [InlineData("#123 @ 3,2: 5x4", "#123 @ 3,2: 5x4", 20)]
        public void FabricRecordsDOublieClaim(string claim1, string claim2, int numberOfClaimedSquares)
        {
            var fabric = new Fabric();
            fabric.MakeClaim(Claim.Parse(claim1));
            fabric.MakeClaim(Claim.Parse(claim2));

            Assert.Equal(numberOfClaimedSquares, fabric.NumberOfClaimedSquares());

        }
    }
}

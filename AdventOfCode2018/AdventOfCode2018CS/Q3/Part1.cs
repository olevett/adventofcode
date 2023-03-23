using System.Linq;

namespace AdventOfCode2018CS.Q3
{
    public static class Part1
    {
        public static int CalculateNumberOfDoublyClaimedSquares(this string input)
        {
            var fabric = new Fabric();
            var claims = input.SplitOnNewLines()
                .Select(Claim.Parse);

            foreach(var claim in claims)
            {
                fabric.MakeClaim(claim);
            }

            return fabric.NumberOfDoublyClaimedSquares();
        }

        public static int IdOfNonOverlappingClaim(this string input)
        {
            var fabric = new Fabric();
            var claims = input.SplitOnNewLines()
                .Select(Claim.Parse);

            foreach (var claim in claims)
            {
                fabric.MakeClaim(claim);
            }

            return claims.Where(x => !fabric.ClaimOverlapsExcludingSelf(x)).Single().Id;
        }
    }
}

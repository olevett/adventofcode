using System.Linq;

namespace AdventOfCode2018CS.Q3
{
    public class Fabric
    {
        private readonly int[,] squares = new int[1000, 1000];
        public void MakeClaim(Claim claim)
        {
            var xRange = Enumerable.Range(claim.Left, claim.Width);
            var yRange = Enumerable.Range(claim.Top, claim.Height);
            foreach(var x in xRange)
            {
                foreach (var y in yRange)
                {
                    squares[x, y]++;
                }
            }            
        }

        public bool ClaimOverlapsExcludingSelf(Claim claim)
        {
            var xRange = Enumerable.Range(claim.Left, claim.Width);
            var yRange = Enumerable.Range(claim.Top, claim.Height);
            foreach (var x in xRange)
            {
                foreach (var y in yRange)
                {
                    if (squares[x, y] > 1) return true;
                }
            }
            return false;
        }

        public int NumberOfClaimedSquares()
        {
            return squares.Cast<int>().Count(x => x >= 1);
        }

        public int NumberOfDoublyClaimedSquares()
        {
            return squares.Cast<int>().Count(x => x >= 2);
        }
    }
}

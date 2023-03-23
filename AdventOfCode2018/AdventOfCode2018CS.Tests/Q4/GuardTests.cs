using AdventOfCode2018CS.Q4;
using Xunit;

namespace AdventOfCode2018CS.Tests.Q4
{
    public class GuardTests
    {
        [Fact]
        public void CountsCorrectly()
        {
            var guard = new Guard(new GuardId(1));
            guard.Sleep(new Minute(1));
            guard.Wake(new Minute(2));

            Assert.Equal(1, guard.GetMinutesAsleep());
            Assert.Equal(1, guard.GetMinuteMostAsleep());
        }

        [Fact]
        public void CountsCorrectlyAgain()
        {
            var guard = new Guard(new GuardId(1));
            guard.Sleep(new Minute(1));
            guard.Wake(new Minute(2));

            guard.Sleep(new Minute(1));
            guard.Wake(new Minute(6));

            Assert.Equal(6, guard.GetMinutesAsleep());
            Assert.Equal(1, guard.GetMinuteMostAsleep());
        }
    }
}

using System.Collections.Generic;

namespace AdventOfCode2018CS.Q4
{
    public class GuardSleep
    {
        private List<GuardId> guardIds;
        public IEnumerable<GuardId> GuardSleeps { get { return guardIds; } }

        public void Sleep(GuardId guardId)
        {
            guardIds.Add(guardId);
        }
    }
}
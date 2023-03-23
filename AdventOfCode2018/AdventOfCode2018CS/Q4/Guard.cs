using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018CS.Q4
{
    public class Guard
    {
        private readonly GuardId id;
        private int previouslyAsleep;
        private readonly Dictionary<int, int> minutesAsleep;
        private int totalAsleep = 0;

        public Guard(GuardId id)
        {
            this.id = id;
            minutesAsleep = new Dictionary<int, int>();
        }

        public void Sleep(int minute)
        {
            previouslyAsleep = minute;
        }

        public void Wake(int minute)
        {
            totalAsleep += minute - previouslyAsleep;
            var minutes = Enumerable.Range(previouslyAsleep, minute - previouslyAsleep);

            foreach (var sleepyMinute in minutes)
            {
                if(!minutesAsleep.ContainsKey(sleepyMinute))
                {
                    minutesAsleep[sleepyMinute] = 1;
                }
                else
                {
                    minutesAsleep[sleepyMinute] += 1;
                }
            }
        }

        public int GetMinutesAsleep() => totalAsleep;

        public int GetMinuteMostAsleep() => minutesAsleep.OrderByDescending(x=>x.Value).Select(x=>x.Key).First();
    }
}

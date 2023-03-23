using System;

namespace AdventOfCode2018CS.Q4
{
    public abstract class Command
    {
        private readonly DateTime dateTime;

        public Command(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2018CS.Q4
{
    public class CommandParser
    {
        public Command ReadLine(string input)
        {
            var matches = Regex.Match(input, @"[(\d*-\d*-\d* \d\d:\d\d)].*");
            var commandTime = DateTime.Parse(matches.Groups[1].Value);
            //DateTime commandTime = 

            if(input.EndsWith("wakes up"))
            {
                return new SleepEnd(commandTime);
            }
            else if(input.EndsWith("falls aslee"))
            {
                return new SleepStarts(commandTime);
            }
            return new ShiftStart();

        }
    }
}

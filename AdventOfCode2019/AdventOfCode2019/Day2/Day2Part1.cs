using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Day2
{
    public class Day2Part1
    {
        public int Process(string input)
        {
            var program = input.Split(',').Select(int.Parse);
            var initialProgramState = new ProgramState(program, false, 0);
            return SetUntilHalt(initialProgramState).Program.First();
        }

        public ProgramState SetUntilHalt(ProgramState program)
        {
            if(program.Halt)
            {
                return program;
            }
            return SetUntilHalt(program.Process());
        }


        public class ProgramState
        {
            public IEnumerable<int> Program { get; }
            public bool Halt { get; }
            public int ProgramCounter { get; }

            public ProgramState(IEnumerable<int> program, bool halt, int programCounter)
            {
                this.Program = program;
                this.Halt = halt;
                this.ProgramCounter = programCounter;
            }
            
            public ProgramState Process()
            {
                if (Program.ElementAt(ProgramCounter) == 99)
                {
                    return new ProgramState(Program, true, ProgramCounter);
                }
                else if (Program.ElementAt(ProgramCounter) == 1)
                {
                    return new ProgramState(Program.EnumerableWith(Program.ElementAt(ProgramCounter + 3), Program.ElementAt(Program.ElementAt(ProgramCounter + 1)) + Program.ElementAt(Program.ElementAt(ProgramCounter + 2))), false, ProgramCounter + 4);
                }
                else if (Program.ElementAt(ProgramCounter) == 2)
                {
                    return new ProgramState(Program.EnumerableWith(Program.ElementAt(ProgramCounter + 3), Program.ElementAt(Program.ElementAt(ProgramCounter + 1)) * Program.ElementAt(Program.ElementAt(ProgramCounter + 2))), false, ProgramCounter + 4);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }

    public static class Extensions
    {
        public static IEnumerable<T> EnumerableWith<T>(this IEnumerable<T> enumerable, int index, T value)
        {
            var input = enumerable.ToList();
            input[index] = value;
            return input;
        }
    }
}

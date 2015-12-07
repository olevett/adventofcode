using System;
using System.Collections.Generic;
using AdventOfCode.Helpers;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day6
    {
        private const string TurnOn = "turn on";
        private const string TurnOff = "turn off";
        private const string Toggle = "toggle";
        private Regex regex = new Regex("(toggle|turn on|turn off) ([0-9]{1,3}),([0-9]{1,3}) through ([0-9]{1,3}),([0-9]{1,3})");

        private enum Operation { TurnOn, TurnOff, Toggle };

        public int TotalTurnedOn(string input)
        {
            IDictionary<Light, bool> map = new Dictionary<Light, bool>();
            var instructions = input.SplitOnNewLines();
            foreach (var instruction in instructions)
            {
                ParseInstruction(instruction, map);
            }
            return map.Count((kvp) => kvp.Value);
        }

        private  void ParseInstruction(string instruction, IDictionary<Light, bool> map)
        {
            var matches = regex.Match(instruction);
            var x0 = int.Parse(matches.Groups[2].Value);
            var y0 = int.Parse(matches.Groups[3].Value);
            var x1 = int.Parse(matches.Groups[4].Value);
            var y1 = int.Parse(matches.Groups[5].Value);

            var operation = GetOperation(instruction);

            for (var x = x0; x <= x1; x++)
            {
                for (var y = y0; y <= y1; y++)
                {
                    var light = new Light(x, y);
                    switch (operation)
                    {
                        case Operation.Toggle:
                            map.AddOrUpdate(light, true, (_, v) => !v);
                            break;
                        case Operation.TurnOn:
                            map.AddOrUpdate(light, true, (_, v) => true);
                            break;
                        case Operation.TurnOff:
                            map.AddOrUpdate(light, false, (_, v) => false);
                            break;
                    }
                }
                
            }
        }

        public int TotalBrightness(string input)
        {
            IDictionary<Light, int> map = new Dictionary<Light, int>();
            var instructions = input.SplitOnNewLines();
            foreach (var instruction in instructions)
            {
                ParseInstructionBrightness(instruction, map);
            }
            return map.Sum((kvp) => kvp.Value);
        }

        private void ParseInstructionBrightness(string instruction, IDictionary<Light, int> map)
        {
            var matches = regex.Match(instruction);
            var x0 = int.Parse(matches.Groups[2].Value);
            var y0 = int.Parse(matches.Groups[3].Value);
            var x1 = int.Parse(matches.Groups[4].Value);
            var y1 = int.Parse(matches.Groups[5].Value);

            var operation = GetOperation(instruction);

            for (var x = x0; x <= x1; x++)
            {
                for (var y = y0; y <= y1; y++)
                {
                    var light = new Light(x, y);
                    switch (operation)
                    {
                        case Operation.Toggle:
                            map.AddOrUpdate(light, 2, (_, v) => v += 2);
                            break;
                        case Operation.TurnOn:
                            map.AddOrUpdate(light, 1, (_, v) => ++v);
                            break;
                        case Operation.TurnOff:
                            map.AddOrUpdate(light, 0, (_, v) => Math.Max(--v, 0));
                            break;
                    }
                }
            }
        }

        private  Operation GetOperation(string instruction)
        {
            if (instruction.StartsWith(TurnOn)) return Operation.TurnOn;
            if (instruction.StartsWith(TurnOff)) return Operation.TurnOff;
            if (instruction.StartsWith(Toggle)) return Operation.Toggle;
            throw new InvalidOperationException();
        }

        public class Light : Tuple<int, int>
        {
            public Light(int x, int y)
                : base(x, y)
            {
            }

            public int X
            {
                get { return Item1; }
            }

            public int Y
            {
                get { return Item2; }
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                var other = (Light)obj;

                if (other.X != this.X) return false;
                if (other.Y != this.Y) return false;

                return true;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}

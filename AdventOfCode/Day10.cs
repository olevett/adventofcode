using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day10
    {
        public string LookAndSay(string input, int repetitions)
        {
            for (var i = 0; i < repetitions; i++ )
            {
                input = LookAndSay(input);
            }
            return input;
        }

        public string LookAndSay(string input)
        {
            var stack = new Stack<Tuple<char, int>>();

            foreach (var character in input)
            {
                if (stack.Count > 0 && stack.Peek().Item1 == character)
                {
                    var end = stack.Pop();
                    stack.Push(new Tuple<char, int>(end.Item1, end.Item2 + 1));
                }
                else
                {
                    stack.Push(new Tuple<char, int>(character, 1));
                }
            }
            return String.Join("", stack.Reverse().Select(x => string.Format("{0}{1}", x.Item2, x.Item1)));
        }
    }
}

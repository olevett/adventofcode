using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018CS.Q1
{
    public class Part2
    {
        public int CalculateFirstDuplicate(string input)
        {
            var array = input.Split(new[] { ",", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var x = Enumerable.Concat(new[] { 0 },
                    array
                    .Select(int.Parse)
                    .RepeatIndefinitely()
                    .CumulativeSum());

            var list = new List<int>();
            foreach (var item in x)
            {
                if(list.Contains(item))
                {
                    return item;
                }
                list.Add(item);
            }

            return -1;
        }

        public static IEnumerable<IEnumerable<int>> returnMany(IEnumerable<int> e)
        {
            yield return e;
        }
    }

    public static class Part2Helpers
    {
        public static IEnumerable<int> CumulativeSum(this IEnumerable<int> sequence)
        {
            var sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
                yield return sum;
            }
        }

        public static IEnumerable<T> RepeatIndefinitely<T>(this IEnumerable<T> source)
        {
            while (true)
            {
                foreach (var item in source)
                {
                    yield return item;
                }
            }
        }
    }
}

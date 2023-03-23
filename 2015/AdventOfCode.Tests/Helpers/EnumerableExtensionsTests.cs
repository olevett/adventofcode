using AdventOfCode.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode.Tests.Helpers
{
    public class EnumerableExtensionsTests
    {
        [Theory]
        [InlineData(new[] { "London", "Dublin" }, 2)]
        [InlineData(new[] { "London", "Dublin", "Belfast" }, 6)]
        public void GetPermuationsWithLength(IEnumerable<string> input, int expectedPermutations)
        {
            var actualPermutations = input.GetPermutations(input.Count()).Count();
            Assert.Equal(expectedPermutations, actualPermutations);
        }

        [Theory]
        [InlineData(new[] { "London", "Dublin" }, 2)]
        [InlineData(new[] { "London", "Dublin", "Belfast" }, 6)]
        public void GetPermuations(IEnumerable<string> input, int expectedPermutations)
        {
            var actualPermutations = input.GetPermutations().Count();
            Assert.Equal(expectedPermutations, actualPermutations);
        }
    }
}

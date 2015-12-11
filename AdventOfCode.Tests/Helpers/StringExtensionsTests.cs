using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using AdventOfCode.Helpers;

namespace AdventOfCode.Tests.Helpers
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("a\r\nb", 2)]
        public void SplitsOnNewLines(string input, int expected)
        {
            var actual = input.SplitOnNewLines().Count();
            Assert.Equal(expected, actual);
        }
    }
}

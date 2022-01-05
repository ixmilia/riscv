using System;
using System.Text;
using Xunit;

namespace RiscV.Test
{
    public abstract class TestBase
    {
        protected static string Intersperse(string s, char c, params int[] indicies)
        {
            var sb = new StringBuilder();
            var currentIndex = 0;
            foreach (var i in indicies)
            {
                sb.Append(s.Substring(currentIndex, i - currentIndex));
                sb.Append(c);
                currentIndex = i;
            }

            sb.Append(s.Substring(currentIndex));
            return sb.ToString();
        }

        protected static string AsBinary(uint value)
        {
            var result = Convert.ToString(value, 2);
            var prefix = new string('0', 32 - result.Length);
            var full = prefix + result;
            return Intersperse(full, '_', 7, 12, 17, 20, 25);
        }

        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var expectedS = AsBinary(expected);
            var actualS = AsBinary(actual);
            Assert.Equal(expectedS, actualS);
        }
    }
}

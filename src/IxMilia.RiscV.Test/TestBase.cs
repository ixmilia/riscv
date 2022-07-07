using System;
using System.Text;
using Xunit;

namespace IxMilia.RiscV.Test
{
    public abstract class TestBase
    {
        protected static ExecutionStateRV32I CreateExecutionState() => new ExecutionStateRV32I();

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

        protected static string AsBinary(uint value, params int[] indicies)
        {
            var result = Convert.ToString(value, 2);
            var prefix = new string('0', 32 - result.Length);
            var full = prefix + result;
            return Intersperse(full, '_', indicies);
        }

        protected static void AssertInstruction(IInstructionRV32I instruction, string expected)
        {
            var actual = instruction.ToString()!;
            Assert.Equal(expected, actual);

            var parsed = IInstructionRV32I.Parse(actual);
            var expectedBinary = AsBinary(instruction.Code, 8, 16, 24);
            var actualBinary = AsBinary(parsed.Code, 8, 16, 24);
            Assert.Equal(expectedBinary, actualBinary);
        }
    }
}

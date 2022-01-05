using System;
using System.Text;
using Xunit;

namespace RiscV.Test
{
    public class EncodingTests_32I_R
    {
        private static string Intersperse(string s, char c, params int[] indicies)
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

        private static string AsBinary(uint value)
        {
            var result = Convert.ToString(value, 2);
            var prefix = new string('0', 32 - result.Length);
            var full = prefix + result;
            return Intersperse(full, '_', 7, 12, 17, 20, 25);
        }

        private static void AssertEqualBinary(uint expected, uint actual)
        {
            var expectedS = AsBinary(expected);
            var actualS = AsBinary(actual);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void Add()
        {
            var i = InstructionRV32I_R.Add(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0000000_00100_00010_000_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }

        [Fact]
        public void Sub()
        {
            var i = InstructionRV32I_R.Sub(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0100000_00100_00010_000_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }

        [Fact]
        public void Sll()
        {
            var i = InstructionRV32I_R.Sll(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0000000_00100_00010_001_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }
    }
}

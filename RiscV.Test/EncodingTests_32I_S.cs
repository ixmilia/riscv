using Xunit;

namespace RiscV.Test
{
    public class EncodingTests_32I_S : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 7, 12, 17, 20, 25 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void SW()
        {
            var i = InstructionRV32I_S.SW(RegisterAddressRV32I.R2, RegisterAddressRV32I.R4, 0b1100011_10101);
            AssertEqualBinary(0b1100011_00100_00010_010_10101_0100011u, i.Code);
            //                  imm110  rs2   rs1   f3  imm40  opcode
        }
    }
}

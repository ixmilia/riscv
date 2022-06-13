using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_S : TestBase
    {
        private static InstructionRV32I_S Decode(uint code) => InstructionRV32I_S.Decode(code);

        [Fact]
        public void SW()
        {
            var c = Decode(0b1100011_00100_00010_010_10101_0100011u);
            //               imm110  rs2   rs1   f3  imm40  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            var expected = 0b11111111111111111111_1100011_10101u;
            //                     sign extension
            Assert.Equal((int)expected, c.ImmediateValue);
        }
    }
}

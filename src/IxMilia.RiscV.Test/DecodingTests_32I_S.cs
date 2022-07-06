using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_S : TestBase
    {
        private static InstructionRV32I_S Decode(uint code) => InstructionRV32I_S.Decode(code);

        [Fact]
        public void S_rs1()
        {
            var c = Decode(0b0000000_00000_11111_010_00000_0100011u);
            //               imm115  rs2   rs1   f3  imm40 opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.SourceRegister1);
        }

        [Fact]
        public void S_rs2()
        {
            var c = Decode(0b0000000_11111_00000_010_00000_0100011u);
            //               imm115  rs2   rs1   f3  imm40 opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.SourceRegister2);
        }

        [Fact]
        public void S_Immediate_4_0()
        {
            var c = Decode(0b0000000_00000_00000_010_11111_0100011u);
            //               imm115  rs2   rs1   f3  imm40 opcode
            Assert.Equal(0b11111, c.ImmediateValue);
        }

        [Fact]
        public void S_Immediate_11_5()
        {
            var c = Decode(0b1111111_00000_00000_010_00000_0100011u);
            //               imm115  rs2   rs1   f3  imm40 opcode
            Assert.Equal(0b11111111111111111111111111100000u, (uint)c.ImmediateValue);
        }

        [Fact]
        public void SW()
        {
            var c = Decode(0b1100011_00100_00010_010_10101_0100011u);
            //               imm115  rs2   rs1   f3  imm40 opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            var expected = 0b11111111111111111111_1100011_10101u;
            //                     sign extension
            Assert.Equal((int)expected, c.ImmediateValue);
        }

        [Fact]
        public void SH()
        {
            var c = Decode(0b1100011_00100_00010_001_10101_0100011u);
            //               imm115  rs2   rs1   f3  imm40 opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            var expected = 0b11111111111111111111_1100011_10101u;
            //                     sign extension
            Assert.Equal((int)expected, c.ImmediateValue);
        }
    }
}

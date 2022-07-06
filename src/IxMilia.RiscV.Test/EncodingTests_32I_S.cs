using Xunit;

namespace IxMilia.RiscV.Test
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
        public void S_rs1()
        {
            var i = InstructionRV32I_S.SW(RegisterAddressRV32I.R31, RegisterAddressRV32I.R0, 0);
            AssertEqualBinary(0b0000000_00000_11111_010_00000_0100011u, i.Code);
            //                  imm110  rs2   rs1   f3  imm40  opcode
        }

        [Fact]
        public void S_rs2()
        {
            var i = InstructionRV32I_S.SW(RegisterAddressRV32I.R0, RegisterAddressRV32I.R31, 0);
            AssertEqualBinary(0b0000000_11111_00000_010_00000_0100011u, i.Code);
            //                  imm110  rs2   rs1   f3  imm40  opcode
        }

        [Fact]
        public void S_Immediate_4_0()
        {
            var i = InstructionRV32I_S.SW(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0b11111);
            AssertEqualBinary(0b0000000_00000_00000_010_11111_0100011u, i.Code);
            //                  imm110  rs2   rs1   f3  imm40  opcode
        }

        [Fact]
        public void S_Immediate_11_5()
        {
            var i = InstructionRV32I_S.SW(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0b111111100000);
            AssertEqualBinary(0b1111111_00000_00000_010_00000_0100011u, i.Code);
            //                  imm110  rs2   rs1   f3  imm40  opcode
        }

        [Fact]
        public void SW()
        {
            var i = InstructionRV32I_S.SW(RegisterAddressRV32I.R2, RegisterAddressRV32I.R4, 0b1100011_10101);
            AssertEqualBinary(0b1100011_00100_00010_010_10101_0100011u, i.Code);
            //                  imm110  rs2   rs1   f3  imm40  opcode
        }

        [Fact]
        public void SH()
        {
            var i = InstructionRV32I_S.SH(RegisterAddressRV32I.R2, RegisterAddressRV32I.R4, 0b1100011_10101);
            AssertEqualBinary(0b1100011_00100_00010_001_10101_0100011u, i.Code);
            //                  imm110  rs2   rs1   f3  imm40  opcode
        }

        [Fact]
        public void SB()
        {
            var i = InstructionRV32I_S.SB(RegisterAddressRV32I.R2, RegisterAddressRV32I.R4, 0b1100011_10101);
            AssertEqualBinary(0b1100011_00100_00010_000_10101_0100011u, i.Code);
            //                  imm110  rs2   rs1   f3  imm40  opcode
        }
    }
}

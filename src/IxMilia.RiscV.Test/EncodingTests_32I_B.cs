using Xunit;

namespace IxMilia.RiscV.Test
{
    public class EncodingTests_32I_B : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 1, 7, 12, 17, 20, 24, 25 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void Branch_Immediate_4_1()
        {
            var i = InstructionRV32I_B.Beq(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0b11110);
            AssertEqualBinary(0b0_000000_00000_00000_000_1111_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void Branch_Immediate_10_5()
        {
            var i = InstructionRV32I_B.Beq(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0b11111100000);
            AssertEqualBinary(0b0_111111_00000_00000_000_0000_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void Branch_Immediate_11()
        {
            var i = InstructionRV32I_B.Beq(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0b100000000000);
            AssertEqualBinary(0b0_000000_00000_00000_000_0000_1_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void Branch_Immediate_12()
        {
            var i = InstructionRV32I_B.Beq(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0b1000000000000);
            AssertEqualBinary(0b1_000000_00000_00000_000_0000_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void Branch_rs1()
        {
            var i = InstructionRV32I_B.Beq(RegisterAddressRV32I.R31, RegisterAddressRV32I.R0, 0);
            AssertEqualBinary(0b0_000000_00000_11111_000_0000_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void Branch_rs2()
        {
            var i = InstructionRV32I_B.Beq(RegisterAddressRV32I.R0, RegisterAddressRV32I.R31, 0);
            AssertEqualBinary(0b0_000000_11111_00000_000_0000_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void Beq_Funct3()
        {
            var i = InstructionRV32I_B.Beq(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0);
            AssertEqualBinary(0b0_000000_00000_00000_000_0000_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void Bne_Funct3()
        {
            var i = InstructionRV32I_B.Bne(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0);
            AssertEqualBinary(0b0_000000_00000_00000_001_0000_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void Blt_Funct3()
        {
            var i = InstructionRV32I_B.Blt(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0);
            AssertEqualBinary(0b0_000000_00000_00000_100_0000_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }

        [Fact]
        public void BltU_Funct3()
        {
            var i = InstructionRV32I_B.BltU(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0);
            AssertEqualBinary(0b0_000000_00000_00000_110_0000_0_1100011u, i.Code);
            //                  imm12    rs2   rs1       imm41  opcode
            //                    imm105             funct3   imm11
        }
    }
}

using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_B : TestBase
    {
        private static InstructionRV32I_B Decode(uint code) => (InstructionRV32I_B)ExecutionStateRV32I.Decode(code);

        [Fact]
        public void Branch_Immediate_4_1()
        {
            var c = Decode(0b0_000000_00000_00000_000_1111_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            Assert.Equal(0b11110, c.Immediate);
        }

        [Fact]
        public void Branch_Immediate_10_5()
        {
            var c = Decode(0b0_111111_00000_00000_000_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            Assert.Equal(0b11111100000, c.Immediate);
        }

        [Fact]
        public void Branch_Immediate_11()
        {
            var c = Decode(0b0_000000_00000_00000_000_0000_1_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            Assert.Equal(0b100000000000, c.Immediate);
        }

        [Fact]
        public void Branch_Immediate_12()
        {
            var c = Decode(0b1_000000_00000_00000_000_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            Assert.Equal(0b1000000000000, c.Immediate);
        }

        [Fact]
        public void Branch_rs1()
        {
            var c = Decode(0b0_000000_00000_11111_000_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            Assert.Equal(RegisterAddressRV32I.R31, c.Source1);
        }

        [Fact]
        public void Branch_rs2()
        {
            var c = Decode(0b0_000000_11111_00000_000_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            Assert.Equal(RegisterAddressRV32I.R31, c.Source2);
        }

        [Fact]
        public void Beq_Funct3()
        {
            var c = Decode(0b0_000000_00000_00000_000_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            // just by decoding we know it's good
        }

        [Fact]
        public void Bne_Funct3()
        {
            var c = Decode(0b0_000000_00000_00000_001_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            // just by decoding we know it's good
        }

        [Fact]
        public void Blt_Funct3()
        {
            var c = Decode(0b0_000000_00000_00000_100_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            // just by decoding we know it's good
        }

        [Fact]
        public void BltU_Funct3()
        {
            var c = Decode(0b0_000000_00000_00000_110_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            // just by decoding we know it's good
        }

        [Fact]
        public void Bge_Funct3()
        {
            var c = Decode(0b0_000000_00000_00000_101_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            // just by decoding we know it's good
        }

        [Fact]
        public void BgeU_Funct3()
        {
            var c = Decode(0b0_000000_00000_00000_111_0000_0_1100011u);
            //               imm12    rs2   rs1       imm41  opcode
            //                 imm105             funct3   imm11
            // just by decoding we know it's good
        }
    }
}

using Xunit;

namespace IxMilia.RiscV.Test
{
    public class EncodingTests_32I_J : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 1, 11, 12, 20, 25 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void J_rd()
        {
            var i = InstructionRV32I_J.Jal(RegisterAddressRV32I.R31, 0);
            AssertEqualBinary(0b0_0000000000_0_00000000_11111_1101111u, i.Code);
            //             imm20 imm10:1 imm11 imm19:12 dest  opcode
        }

        [Fact]
        public void J_Immediate_20()
        {
            var i = InstructionRV32I_J.Jal(RegisterAddressRV32I.R0, 0b100000000000000000000);
            AssertEqualBinary(0b1_0000000000_0_00000000_00000_1101111u, i.Code);
            //             imm20 imm10:1 imm11 imm19:12 dest  opcode
        }

        [Fact]
        public void J_Immediate_19_12()
        {
            var i = InstructionRV32I_J.Jal(RegisterAddressRV32I.R0, 0b11111111000000000000);
            AssertEqualBinary(0b0_0000000000_0_11111111_00000_1101111u, i.Code);
            //             imm20 imm10:1 imm11 imm19:12 dest  opcode
        }

        [Fact]
        public void J_Immediate_11()
        {
            var i = InstructionRV32I_J.Jal(RegisterAddressRV32I.R0, 0b100000000000);
            AssertEqualBinary(0b0_0000000000_1_00000000_00000_1101111u, i.Code);
            //             imm20 imm10:1 imm11 imm19:12 dest  opcode
        }

        [Fact]
        public void J_Immediate_10_1()
        {
            var i = InstructionRV32I_J.Jal(RegisterAddressRV32I.R0, 0b11111111110);
            AssertEqualBinary(0b0_1111111111_0_00000000_00000_1101111u, i.Code);
            //             imm20 imm10:1 imm11 imm19:12 dest  opcode
        }

        [Fact]
        public void Jal()
        {
            var i = InstructionRV32I_J.Jal(RegisterAddressRV32I.R17, -4);
            AssertEqualBinary(0b1_1111111110_1_11111111_10001_1101111u, i.Code);
            //           imm20 imm10:1 imm11 imm19:12   dest  opcode
        }
    }
}

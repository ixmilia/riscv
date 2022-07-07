using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_J : TestBase
    {
        protected static void AssertEqualBinary(int expected, int actual) => AssertEqualBinary((uint)expected, (uint)actual);

        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 8, 16, 24 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        private static InstructionRV32I_J Decode(uint code) => (InstructionRV32I_J)ExecutionStateRV32I.Decode(code);

        [Fact]
        public void J_rd()
        {
            var c = Decode(0b0_0000000000_0_00000000_11111_1101111u);
            //          imm20 imm10:1 imm11 imm19:12 dest  opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.DestinationRegister);
        }

        [Fact]
        public void J_Immediate_20()
        {
            var c = Decode(0b1_0000000000_0_00000000_00000_1101111u);
            //          imm20 imm10:1 imm11 imm19:12 dest  opcode
            AssertEqualBinary(0b11111111111100000000000000000000u, (uint)c.AddressOffset);
        }

        [Fact]
        public void J_Immediate_19_12()
        {
            var c = Decode(0b0_0000000000_0_11111111_00000_1101111u);
            //          imm20 imm10:1 imm11 imm19:12 dest  opcode
            AssertEqualBinary(0b11111111000000000000u, (uint)c.AddressOffset);
        }

        [Fact]
        public void J_Immediate_11()
        {
            var c = Decode(0b0_0000000000_1_00000000_00000_1101111u);
            //          imm20 imm10:1 imm11 imm19:12 dest  opcode
            AssertEqualBinary(0b100000000000, c.AddressOffset);
        }

        [Fact]
        public void J_Immediate_10_1()
        {
            var c = Decode(0b0_1111111111_0_00000000_00000_1101111u);
            //          imm20 imm10:1 imm11 imm19:12 dest  opcode
            AssertEqualBinary(0b11111111110, c.AddressOffset);
        }

        [Fact]
        public void Jal()
        {
            var c = Decode(0b1_1111111110_1_11111111_10001_1101111u);
            //        imm20 imm10:1 imm11 imm19:12   dest  opcode
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
            AssertEqualBinary(-4, c.AddressOffset);
        }
    }
}

using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_J : TestBase
    {
        protected static void AssertEqualBinary(int expected, int actual)
        {
            var indices = new[] { 8, 16, 24 };
            var expectedS = AsBinary((uint)expected, indices);
            var actualS = AsBinary((uint)actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        private static InstructionRV32I_J Decode(uint code) => InstructionRV32I_J.Decode(code);

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

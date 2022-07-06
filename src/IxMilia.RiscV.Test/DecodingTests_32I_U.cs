using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_U : TestBase
    {
        private static InstructionRV32I_U Decode(uint code) => InstructionRV32I_U.Decode(code);

        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 8, 16 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void U_rd()
        {
            var c = Decode(0b00000000000000000000_11111_0110111u);
            //               immediate            dest  opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.DestinationRegister);
        }

        [Fact]
        public void U_Immediate_31_12()
        {
            var c = Decode(0b11111111111111111111_00000_0110111u);
            //               immediate            dest  opcode
            AssertEqualBinary(0b11111111111111111111000000000000u, c.ImmediateValue);
        }

        [Fact]
        public void Lui()
        {
            var c = Decode(0b10101010101010101010_10001_0110111u);
            //               immediate            dest  opcode
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
            AssertEqualBinary(0b10101010101010101010000000000000u, c.ImmediateValue);
        }

        [Fact]
        public void AuiPC()
        {
            var c = Decode(0b10101010101010101010_10001_0010111u);
            //               immediate            dest  opcode
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
            AssertEqualBinary(0b10101010101010101010000000000000u, c.ImmediateValue);
        }
    }
}

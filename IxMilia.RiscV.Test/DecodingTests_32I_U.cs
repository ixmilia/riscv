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
        public void Lui()
        {
            var c = Decode(0b10101010101010101010_10001_0110111u);
            //               immediate            dest  opcode
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
            AssertEqualBinary(0b10101010101010101010u, c.ImmediateValue);
        }

        [Fact]
        public void AuiPC()
        {
            var c = Decode(0b10101010101010101010_10001_0010111u);
            //               immediate            dest  opcode
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
            AssertEqualBinary(0b10101010101010101010u, c.ImmediateValue);
        }
    }
}

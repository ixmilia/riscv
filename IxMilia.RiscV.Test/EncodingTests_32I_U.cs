using Xunit;

namespace IxMilia.RiscV.Test
{
    public class EncodingTests_32I_U : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 20, 25 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void Lui()
        {
            var i = InstructionRV32I_U.Lui(RegisterAddressRV32I.R17, 0b10101010101010101010u);
            AssertEqualBinary(0b10101010101010101010_10001_0110111u, i.Code);
            //                  immediate            dest  opcode
        }

        [Fact]
        public void AuiPC()
        {
            var i = InstructionRV32I_U.AuiPC(RegisterAddressRV32I.R17, 0b10101010101010101010u);
            AssertEqualBinary(0b10101010101010101010_10001_0010111u, i.Code);
            //                  immediate            dest  opcode
        }
    }
}

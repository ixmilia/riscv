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
        public void U_rd()
        {
            var i = InstructionRV32I_U.Lui(RegisterAddressRV32I.R31, 0);
            AssertEqualBinary(0b00000000000000000000_11111_0110111u, i.Code);
            //                  immediate            dest  opcode
        }

        [Fact]
        public void U_Immediate_31_12()
        {
            var i = InstructionRV32I_U.Lui(RegisterAddressRV32I.R0, 0b11111111111111111111000000000000u);
            AssertEqualBinary(0b11111111111111111111_00000_0110111u, i.Code);
            //                  immediate            dest  opcode
        }

        [Fact]
        public void Lui()
        {
            var i = InstructionRV32I_U.Lui(RegisterAddressRV32I.R17, 0b10101010101010101010000000000000u);
            AssertEqualBinary(0b10101010101010101010_10001_0110111u, i.Code);
            //                  immediate            dest  opcode
        }

        [Fact]
        public void AuiPC()
        {
            var i = InstructionRV32I_U.AuiPC(RegisterAddressRV32I.R17, 0b10101010101010101010000000000000u);
            AssertEqualBinary(0b10101010101010101010_10001_0010111u, i.Code);
            //                  immediate            dest  opcode
        }
    }
}

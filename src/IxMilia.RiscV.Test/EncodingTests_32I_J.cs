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
        public void Jal()
        {
            var i = InstructionRV32I_J.Jal(RegisterAddressRV32I.R17, -4);
            AssertEqualBinary(0b1_1111111110_1_11111111_10001_1101111u, i.Code);
            //           imm20 imm10:1 imm11 imm19:12   dest  opcode
        }
    }
}

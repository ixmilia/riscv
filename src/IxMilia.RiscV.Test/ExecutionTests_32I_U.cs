using Xunit;

namespace IxMilia.RiscV.Test
{
    public class ExecutionTests_32I_U : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 8, 16, 24 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void Lui()
        {
            var e = CreateExecutionState();
            var i = IInstructionRV32I.Lui(RegisterAddressRV32I.R17, 0b1010_10101010_10101011000000000000);
            e.Execute(i);
            AssertEqualBinary(0b10101010_10101010_10110000_00000000u, e.X17);
        }

        [Fact]
        public void AuiPC()
        {
            var e = CreateExecutionState();
            e.PC = 0b0111;
            var i = IInstructionRV32I.AuiPC(RegisterAddressRV32I.R17, 0b10101010101010101011000000000000);
            e.Execute(i);
            AssertEqualBinary(0b10101010_10101010_10110000_00000111u, e.X17);
        }
    }
}

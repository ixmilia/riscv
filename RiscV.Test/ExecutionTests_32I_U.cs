using Xunit;

namespace RiscV.Test
{
    public class ExecutionTests_32I_U : TestBase
    {
        private static ExecutionStateRV32I CreateExecutionState() => new ExecutionStateRV32I();

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
            var i = IInstructionRV32I.Lui(RegisterAddressRV32I.R17, 0b101010101010101011);
            e.Execute(i);
            AssertEqualBinary(0b101010101010101011000000000000u, e.X17);
        }
    }
}

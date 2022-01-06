using Xunit;

namespace RiscV.Test
{
    public class ExecutionTests_32I_I : TestBase
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
        public void AddI()
        {
            var e = CreateExecutionState();
            e.X2 = 2;
            var i = IInstructionRV32I.AddI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            e.Execute(i);
            AssertEqualBinary(6u, e.X17);
        }

        [Fact]
        public void SltI()
        {
            var e = CreateExecutionState();
            e.X2 = 2;
            var i = IInstructionRV32I.SltI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            e.Execute(i);
            AssertEqualBinary(1u, e.X17);
        }

        [Fact]
        public void SltIU()
        {
            var e = CreateExecutionState();
            e.X2 = 2;
            var i = IInstructionRV32I.SltIU(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            e.Execute(i);
            AssertEqualBinary(1u, e.X17);
        }

        [Fact]
        public void AndI()
        {
            var e = CreateExecutionState();
            e.X2 = 7;
            var i = IInstructionRV32I.AndI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            e.Execute(i);
            AssertEqualBinary(0b0100u, e.X17);
        }

        [Fact]
        public void OrI()
        {
            var e = CreateExecutionState();
            e.X2 = 7;
            var i = IInstructionRV32I.OrI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            e.Execute(i);
            AssertEqualBinary(0b11111111_11111111_11111111_11111111u, e.X17);
        }

        [Fact]
        public void XorI()
        {
            var e = CreateExecutionState();
            e.X2 = 7;
            var i = IInstructionRV32I.XorI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            e.Execute(i);
            AssertEqualBinary(0b11111111_11111111_11111111_11111011u, e.X17);
        }

        [Fact]
        public void SllI ()
        {
            var e = CreateExecutionState();
            e.X2 = 0b0111;
            var i = IInstructionRV32I.SllI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 2);
            e.Execute(i);
            AssertEqualBinary(0b00000000_00000000_00000000_00011100u, e.X17);
        }

        [Fact]
        public void SrlI()
        {
            var e = CreateExecutionState();
            e.X2 = 0b0111;
            var i = IInstructionRV32I.SrlI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 2);
            e.Execute(i);
            AssertEqualBinary(0b00000000_00000000_00000000_00000001u, e.X17);
        }
    }
}

using Xunit;

namespace IxMilia.RiscV.Test
{
    public class ExecutionTests_32I_S : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 8, 16, 24 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void SW()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(32, 0);
            e.AddMemorySegment(m);
            e.X2 = 10;
            e.X4 = 0b1100011_10101;
            var i = IInstructionRV32I.SW(RegisterAddressRV32I.R2, RegisterAddressRV32I.R4, -4);
            e.Execute(i);
            var actual = m.ReadUInt(6);
            AssertEqualBinary(0b1100011_10101, actual);
        }

        [Fact]
        public void SH()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(32, 0);
            e.AddMemorySegment(m);
            e.X2 = 10;
            e.X4 = 0xFFFFFFFF;
            var i = IInstructionRV32I.SH(RegisterAddressRV32I.R2, RegisterAddressRV32I.R4, -4);
            e.Execute(i);
            var actual = m.ReadUInt(6);
            AssertEqualBinary(0xFFFF, actual);
        }

        [Fact]
        public void SB()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(32, 0);
            e.AddMemorySegment(m);
            e.X2 = 10;
            e.X4 = 0xFFFFFFFF;
            var i = IInstructionRV32I.SB(RegisterAddressRV32I.R2, RegisterAddressRV32I.R4, -4);
            e.Execute(i);
            var actual = m.ReadUInt(6);
            AssertEqualBinary(0xFF, actual);
        }
    }
}

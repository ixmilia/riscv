using Xunit;

namespace IxMilia.RiscV.Test
{
    public class ExecutionTests_32I_I : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 8, 16, 24 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void LW()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(128, 0);
            m.WriteUInt(6u, 0x12345678);
            e.AddMemorySegment(m);
            e.X2 = 2;
            var i = IInstructionRV32I.LW(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            e.Execute(i);
            AssertEqualBinary(0x12345678, e.X17);
        }

        [Fact]
        public void LH()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(128, 0);
            m.WriteUInt(6u, 0x12345678);
            e.AddMemorySegment(m);
            e.X2 = 2;
            var i = IInstructionRV32I.LH(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            e.Execute(i);
            AssertEqualBinary(0x5678, e.X17);
        }

        [Fact]
        public void LHU()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(128, 0);
            m.WriteUInt(6u, 0x12345678);
            e.AddMemorySegment(m);
            e.X2 = 2;
            var i = IInstructionRV32I.LHU(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            e.Execute(i);
            AssertEqualBinary(0x5678, e.X17);
        }

        [Fact]
        public void LB()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(128, 0);
            m.WriteUInt(6u, 0x12345678);
            e.AddMemorySegment(m);
            e.X2 = 2;
            var i = IInstructionRV32I.LB(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            e.Execute(i);
            AssertEqualBinary(0x78, e.X17);
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
        public void SllI()
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

        [Fact]
        public void SraI()
        {
            var e = CreateExecutionState();
            e.X2 = 0b11111111_11111111_11111111_11111100; // -4
            var i = IInstructionRV32I.SraI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 1);
            e.Execute(i);
            AssertEqualBinary(0b11111111_11111111_11111111_11111110u, e.X17);
        }

        [Fact]
        public void Nop()
        {
            var e = CreateExecutionState();
            var i = IInstructionRV32I.Nop();
            Assert.Equal(0u, e.PC);
            e.Execute(i);
            Assert.Equal(4u, e.PC);
        }

        [Fact]
        public void Jalr()
        {
            var e = CreateExecutionState();
            e.PC = 20;
            e.X2 = 100;
            e.X17 = 0;
            var i = IInstructionRV32I.Jalr(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 15);
            e.Execute(i);
            Assert.Equal(114u, e.PC);
            Assert.Equal(24u, e.X17);
        }
    }
}

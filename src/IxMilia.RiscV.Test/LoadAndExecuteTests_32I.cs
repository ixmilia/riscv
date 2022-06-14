using Xunit;

namespace IxMilia.RiscV.Test
{
    public class LoadAndExecuteTests_32I : TestBase
    {
        [Fact]
        public void AnyValueSetToRegister0IsDiscarded()
        {
            var e = CreateExecutionState();
            var i = IInstructionRV32I.AddI(RegisterAddressRV32I.R0, RegisterAddressRV32I.R1, 4);
            e.Execute(i);
            Assert.Equal(0u, e.X0);
        }

        [Fact]
        public void PCIsIncrementedBy4AfterRegularInstruction()
        {
            var e = CreateExecutionState();
            var m = new ByteMemorySegmentRV32(512, 256);
            var i = InstructionRV32I_R.Add(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4);
            e.AddMemorySegment(m);
            m.WriteUInt(516, i.Code);
            e.PC = 516;
            e.X3 = 6;
            e.X4 = 7;
            e.ExecuteCurrent();
            Assert.Equal(520u, e.PC);
            Assert.Equal(13u, e.X2);
        }
    }
}

using Xunit;

namespace RiscV.Test
{
    public class ExecutionTests_32I_R
    {
        private static ExecutionStateRV32I CreateExecutionState() => new ExecutionStateRV32I();

        [Fact]
        public void Add()
        {
            var e = CreateExecutionState();
            e.X2 = 2;
            e.X4 = 4;
            var add = IInstructionRV32I.Add(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(add);
            Assert.Equal(6u, e.X17);
        }

        [Fact]
        public void Sub()
        {
            var e = CreateExecutionState();
            e.X2 = 4;
            e.X4 = 2;
            var sub = IInstructionRV32I.Sub(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            Assert.Equal(2u, e.X17);
        }

        [Fact]
        public void Sll()
        {
            var e = CreateExecutionState();
            e.X2 = 0b0100;
            e.X4 = 2;
            var sub = IInstructionRV32I.Sll(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            Assert.Equal(0b10000u, e.X17);
        }
    }
}

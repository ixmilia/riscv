using Xunit;

namespace RiscV.Test
{
    public class ExecutionTests_32I_R : TestBase
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
            AssertEqualBinary(6u, e.X17);
        }

        [Fact]
        public void Sub()
        {
            var e = CreateExecutionState();
            e.X2 = 4;
            e.X4 = 2;
            var sub = IInstructionRV32I.Sub(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(2u, e.X17);
        }

        [Fact]
        public void Sll()
        {
            var e = CreateExecutionState();
            e.X2 = 0b0100;
            e.X4 = 2;
            var sub = IInstructionRV32I.Sll(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(0b10000u, e.X17);
        }

        [Fact]
        public void Srl()
        {
            var e = CreateExecutionState();
            e.X2 = 0b0100;
            e.X4 = 2;
            var sub = IInstructionRV32I.Srl(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(0b0001u, e.X17);
        }

        [Fact]
        public void Sra()
        {
            var e = CreateExecutionState();
            e.X2 = 0b10000000_00000000_00000000_00000100;
            e.X4 = 2;
            var sub = IInstructionRV32I.Sra(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(0b11100000_00000000_00000000_00000001u, e.X17);
        }

        [Fact]
        public void Slt()
        {
            var e = CreateExecutionState();
            e.X2 = 0b10000000_00000000_00000000_00000100;
            e.X4 = 2;
            var sub = IInstructionRV32I.Slt(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(1, e.X17);
        }
    }
}

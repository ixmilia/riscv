using Xunit;

namespace IxMilia.RiscV.Test
{
    public class ExecutionTests_32I_R : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 8, 16, 24 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

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
            e.X2 = 4;
            e.X4 = 20;
            var sub = IInstructionRV32I.Slt(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(1, e.X17);
        }

        [Fact]
        public void Sltu()
        {
            var e = CreateExecutionState();
            e.X2 = 4;
            e.X4 = 20;
            var sub = IInstructionRV32I.Sltu(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(1, e.X17);
        }

        [Fact]
        public void SltuWithX0()
        {
            var e = CreateExecutionState();
            e.X4 = 2;
            var sub = IInstructionRV32I.Sltu(RegisterAddressRV32I.R17, RegisterAddressRV32I.R0, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(1, e.X17);
        }

        [Fact]
        public void And()
        {
            var e = CreateExecutionState();
            e.X2 = 0b0111;
            e.X4 = 0b0010;
            var sub = IInstructionRV32I.And(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(0b0010, e.X17);
        }

        [Fact]
        public void Or()
        {
            var e = CreateExecutionState();
            e.X2 = 0b0110;
            e.X4 = 0b0011;
            var sub = IInstructionRV32I.Or(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(0b0111, e.X17);
        }

        [Fact]
        public void Xor()
        {
            var e = CreateExecutionState();
            e.X2 = 0b0110;
            e.X4 = 0b0011;
            var sub = IInstructionRV32I.Xor(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            e.Execute(sub);
            AssertEqualBinary(0b0101, e.X17);
        }
    }
}

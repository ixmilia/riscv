using Xunit;

namespace IxMilia.RiscV.Test
{
    public class ExecutionTests_32I_B : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 1, 7, 12, 17, 20, 24, 25 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void Beq_true()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 17;
            var i = IInstructionRV32I.Beq(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(122u, e.PC);
        }

        [Fact]
        public void Beq_false()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 18;
            var i = IInstructionRV32I.Beq(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(104u, e.PC);
        }

        [Fact]
        public void Bne_true()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 18;
            var i = IInstructionRV32I.Bne(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(122u, e.PC);
        }

        [Fact]
        public void Bne_false()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 17;
            var i = IInstructionRV32I.Bne(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(104u, e.PC);
        }

        [Fact]
        public void Blt_true()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 18;
            var i = IInstructionRV32I.Blt(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(122u, e.PC);
        }

        [Fact]
        public void Blt_false()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 17;
            var i = IInstructionRV32I.Blt(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(104u, e.PC);
        }

        [Fact]
        public void BltU_true()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 18;
            var i = IInstructionRV32I.BltU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(122u, e.PC);
        }

        [Fact]
        public void BltU_false()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 17;
            var i = IInstructionRV32I.BltU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(104u, e.PC);
        }

        [Fact]
        public void Bge_true()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 17;
            var i = IInstructionRV32I.Bge(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(122u, e.PC);
        }

        [Fact]
        public void Bge_false()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            e.X2 = 17;
            e.X3 = 18;
            var i = IInstructionRV32I.Bge(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 22);
            e.Execute(i);
            Assert.Equal(104u, e.PC);
        }
    }
}

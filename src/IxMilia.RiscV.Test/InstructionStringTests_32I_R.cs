using Xunit;

namespace IxMilia.RiscV.Test
{
    public class InstructionStringTests_32I_R : TestBase
    {
        [Fact]
        public void Add()
        {
            AssertInstruction(IInstructionRV32I.Add(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "add x2, x3, x4");
        }

        [Fact]
        public void Slt()
        {
            AssertInstruction(IInstructionRV32I.Slt(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "slt x2, x3, x4");
        }

        [Fact]
        public void Sltu()
        {
            AssertInstruction(IInstructionRV32I.Sltu(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "sltu x2, x3, x4");
        }

        [Fact]
        public void And()
        {
            AssertInstruction(IInstructionRV32I.And(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "and x2, x3, x4");
        }

        [Fact]
        public void Or()
        {
            AssertInstruction(IInstructionRV32I.Or(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "or x2, x3, x4");
        }

        [Fact]
        public void Xor()
        {
            AssertInstruction(IInstructionRV32I.Xor(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "xor x2, x3, x4");
        }

        [Fact]
        public void Sll()
        {
            AssertInstruction(IInstructionRV32I.Sll(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "sll x2, x3, x4");
        }

        [Fact]
        public void Srl()
        {
            AssertInstruction(IInstructionRV32I.Srl(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "srl x2, x3, x4");
        }

        [Fact]
        public void Sub()
        {
            AssertInstruction(IInstructionRV32I.Sub(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "sub x2, x3, x4");
        }

        [Fact]
        public void Sra()
        {
            AssertInstruction(IInstructionRV32I.Sra(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, RegisterAddressRV32I.R4), "sra x2, x3, x4");
        }
    }
}

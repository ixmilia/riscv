using Xunit;

namespace IxMilia.RiscV.Test
{
    public class InstructionStringTests_32I_I : TestBase
    {
        [Fact]
        public void Jalr()
        {
            AssertInstruction(IInstructionRV32I.Jalr(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "jalr x2, 0x12(x3)");
        }

        [Fact]
        public void LW()
        {
            AssertInstruction(IInstructionRV32I.LW(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "lw x2, 0x12(x3)");
        }

        [Fact]
        public void LH()
        {
            AssertInstruction(IInstructionRV32I.LH(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "lh x2, 0x12(x3)");
        }

        [Fact]
        public void LHU()
        {
            AssertInstruction(IInstructionRV32I.LHU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "lhu x2, 0x12(x3)");
        }

        [Fact]
        public void LB()
        {
            AssertInstruction(IInstructionRV32I.LB(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "lb x2, 0x12(x3)");
        }

        [Fact]
        public void LBU()
        {
            AssertInstruction(IInstructionRV32I.LBU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "lbu x2, 0x12(x3)");
        }

        [Fact]
        public void AddI()
        {
            AssertInstruction(IInstructionRV32I.AddI(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "addi x2, x3, 0x12");
        }

        [Fact]
        public void SltI()
        {
            AssertInstruction(IInstructionRV32I.SltI(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "slti x2, x3, 0x12");
        }

        [Fact]
        public void SltIU()
        {
            AssertInstruction(IInstructionRV32I.SltIU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "sltiu x2, x3, 0x12");
        }

        [Fact]
        public void AndI()
        {
            AssertInstruction(IInstructionRV32I.AndI(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "andi x2, x3, 0x12");
        }

        [Fact]
        public void OrI()
        {
            AssertInstruction(IInstructionRV32I.OrI(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "ori x2, x3, 0x12");
        }

        [Fact]
        public void XorI()
        {
            AssertInstruction(IInstructionRV32I.XorI(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "xori x2, x3, 0x12");
        }

        [Fact]
        public void SllI()
        {
            AssertInstruction(IInstructionRV32I.SllI(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "slli x2, x3, 0x12");
        }

        [Fact]
        public void SrlI()
        {
            AssertInstruction(IInstructionRV32I.SrlI(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "srli x2, x3, 0x12");
        }
    }
}

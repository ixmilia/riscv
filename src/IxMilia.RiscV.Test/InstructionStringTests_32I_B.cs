using Xunit;

namespace IxMilia.RiscV.Test
{
    public class InstructionStringTests_32I_B : TestBase
    {
        [Fact]
        public void Beq()
        {
            AssertInstruction(IInstructionRV32I.Beq(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "beq x2, x3, 0x1234");
        }

        [Fact]
        public void Bne()
        {
            AssertInstruction(IInstructionRV32I.Bne(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bne x2, x3, 0x1234");
        }

        [Fact]
        public void Blt()
        {
            AssertInstruction(IInstructionRV32I.Blt(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "blt x2, x3, 0x1234");
        }

        [Fact]
        public void BltU()
        {
            AssertInstruction(IInstructionRV32I.BltU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bltu x2, x3, 0x1234");
        }

        [Fact]
        public void Bge()
        {
            AssertInstruction(IInstructionRV32I.Bge(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bge x2, x3, 0x1234");
        }

        [Fact]
        public void BgeU()
        {
            AssertInstruction(IInstructionRV32I.BgeU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bgeu x2, x3, 0x1234");
        }

        [Fact]
        public void Bgt()
        {
            AssertInstruction(IInstructionRV32I.Bgt(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "blt x3, x2, 0x1234");
        }

        [Fact]
        public void BgtU()
        {
            AssertInstruction(IInstructionRV32I.BgtU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bltu x3, x2, 0x1234");
        }

        [Fact]
        public void Ble()
        {
            AssertInstruction(IInstructionRV32I.Ble(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bge x3, x2, 0x1234");
        }

        [Fact]
        public void BleU()
        {
            AssertInstruction(IInstructionRV32I.BleU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bgeu x3, x2, 0x1234");
        }
    }
}

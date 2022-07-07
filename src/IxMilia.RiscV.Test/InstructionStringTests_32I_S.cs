using Xunit;

namespace IxMilia.RiscV.Test
{
    public class InstructionStringTests_32I_S : TestBase
    {
        [Fact]
        public void SW()
        {
            AssertInstruction(IInstructionRV32I.SW(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "sw x3, 0x12(x2)");
        }

        [Fact]
        public void SH()
        {
            AssertInstruction(IInstructionRV32I.SH(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "sh x3, 0x12(x2)");
        }

        [Fact]
        public void SB()
        {
            AssertInstruction(IInstructionRV32I.SB(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x12), "sb x3, 0x12(x2)");
        }
    }
}

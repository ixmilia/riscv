using Xunit;

namespace IxMilia.RiscV.Test
{
    public class InstructionStringTests_32I_U : TestBase
    {
        [Fact]
        public void Lui()
        {
            AssertInstruction(IInstructionRV32I.Lui(RegisterAddressRV32I.R2, 0x12000), "lui x2, 0x12");
        }

        [Fact]
        public void AuiPC()
        {
            AssertInstruction(IInstructionRV32I.AuiPC(RegisterAddressRV32I.R2, 0x12000), "auipc x2, 0x12");
        }
    }
}

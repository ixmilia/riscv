using Xunit;

namespace IxMilia.RiscV.Test
{
    public class InstructionStringTests_32I_J : TestBase
    {
        [Fact]
        public void Jal()
        {
            AssertInstruction(IInstructionRV32I.Jal(RegisterAddressRV32I.R2, 0x12), "jal x2, 0x12");
        }
    }
}

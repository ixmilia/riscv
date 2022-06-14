using Xunit;

namespace IxMilia.RiscV.Test
{
    public class ExecutionTests_32I_J : TestBase
    {
        [Fact]
        public void Jal()
        {
            var e = CreateExecutionState();
            e.PC = 100;
            var i = IInstructionRV32I.Jal(RegisterAddressRV32I.R17, 22);
            e.Execute(i);
            Assert.Equal(122u, e.PC);
            Assert.Equal(104u, e.X17);
        }
    }
}

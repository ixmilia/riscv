using Xunit;

namespace RiscV.Test
{
    public class DecodingTests_32I_I : TestBase
    {
        private static InstructionRV32I_I Decode(uint code) => InstructionRV32I_I.Decode(code);

        [Fact]
        public void AddI()
        {
            var c = Decode(0b111111111100_00010_000_10001_0110011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void SltI()
        {
            var c = Decode(0b111111111100_00010_010_10001_0110011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }
    }
}

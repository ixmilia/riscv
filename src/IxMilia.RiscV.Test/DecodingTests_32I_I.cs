using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_I : TestBase
    {
        private static InstructionRV32I_I Decode(uint code) => InstructionRV32I_I.Decode(code);

        [Fact]
        public void LW()
        {
            var c = Decode(0b111111111100_00010_010_10001_0000011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void AddI()
        {
            var c = Decode(0b111111111100_00010_000_10001_0010011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void SltI()
        {
            var c = Decode(0b111111111100_00010_010_10001_0010011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void SltIU()
        {
            var c = Decode(0b111111111100_00010_011_10001_0010011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(4092u, c.ImmediateValueUnsigned);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void AndI()
        {
            var c = Decode(0b111111111100_00010_111_10001_0010011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void OrI()
        {
            var c = Decode(0b111111111100_00010_110_10001_0010011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void XorI()
        {
            var c = Decode(0b111111111100_00010_100_10001_0010011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void SllI()
        {
            var c = Decode(0b0000000_00010_00010_001_10001_0010011u);
            //               empty   shamt rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(2, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void SrlI()
        {
            var c = Decode(0b0000000_00010_00010_101_10001_0010011u);
            //               empty   shamt rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(2, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void SraI()
        {
            var c = Decode(0b0100000_00010_00010_101_10001_0010011u);
            //                flag   shamt rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(0b00000000_00000000_00000100_00000010u, c.ImmediateValueUnsigned);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Nop()
        {
            var c = Decode(0b000000000000_00000_000_00000_0010011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R0, c.SourceRegister1);
            Assert.Equal(0b00000000_00000000_00000000_00000000u, c.ImmediateValueUnsigned);
            Assert.Equal(RegisterAddressRV32I.R0, c.DestinationRegister);
        }

        [Fact]
        public void Jalr()
        {
            var c = Decode(0b000000001111_00010_000_10001_1101111u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(15, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }
    }
}

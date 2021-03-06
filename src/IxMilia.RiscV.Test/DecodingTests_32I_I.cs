using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_I : TestBase
    {
        private static InstructionRV32I_I Decode(uint code) => (InstructionRV32I_I)ExecutionStateRV32I.Decode(code);

        [Fact]
        public void I_rd()
        {
            var c = Decode(0b000000000000_00000_010_11111_0000011u);
            //               immediate    rs1   f3  rd    opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.DestinationRegister);
        }

        [Fact]
        public void I_rs1()
        {
            var c = Decode(0b000000000000_11111_010_00000_0000011u);
            //               immediate    rs1   f3  rd    opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.SourceRegister1);
        }

        [Fact]
        public void I_Immediate_11_0()
        {
            var c = Decode(0b111111111111_00000_010_00000_0000011u);
            //               immediate    rs1   f3  rd    opcode
            Assert.Equal(0xFFFFFFFFu, (uint)c.ImmediateValue);
        }

        [Fact]
        public void I_ImmediateU_11_0()
        {
            var c = Decode(0b111111111111_00000_010_00000_0000011u);
            //               immediate    rs1   f3  rd    opcode
            Assert.Equal(0b111111111111u, c.ImmediateValueUnsigned);
        }

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
        public void LH()
        {
            var c = Decode(0b111111111100_00010_001_10001_0000011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void LHU()
        {
            var c = Decode(0b111111111100_00010_101_10001_0000011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void LB()
        {
            var c = Decode(0b111111111100_00010_000_10001_0000011u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(-4, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void LBU()
        {
            var c = Decode(0b111111111100_00010_100_10001_0000011u);
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
            var c = Decode(0b000000001111_00010_000_10001_1100111u);
            //               immediate    rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(15, c.ImmediateValue);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }
    }
}

using System;
using Xunit;

namespace IxMilia.RiscV.Test
{
    public class DecodingTests_32I_R : TestBase
    {
        private static InstructionRV32I_R Decode(uint code) => InstructionRV32I_R.Decode(code);

        [Fact]
        public void R_rd()
        {
            var c = Decode(0b0000000_00000_00000_000_11111_0110011u);
            //               funct7  rs2   rs1   f3  rd    opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.DestinationRegister);
        }

        [Fact]
        public void R_rs1()
        {
            var c = Decode(0b0000000_00000_11111_000_00000_0110011u);
            //               funct7  rs2   rs1   f3  rd    opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.SourceRegister1);
        }

        [Fact]
        public void R_rs2()
        {
            var c = Decode(0b0000000_11111_00000_000_00000_0110011u);
            //               funct7  rs2   rs1   f3  rd    opcode
            Assert.Equal(RegisterAddressRV32I.R31, c.SourceRegister2);
        }

        [Fact]
        public void Add()
        {
            var c = Decode(0b0000000_00100_00010_000_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Sub()
        {
            var c = Decode(0b0100000_00100_00010_000_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Sll()
        {
            var c = Decode(0b0000000_00100_00010_001_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Srl()
        {
            var c = Decode(0b0000000_00100_00010_101_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Sra()
        {
            var c = Decode(0b0100000_00100_00010_101_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Slt()
        {
            var c = Decode(0b0000000_00100_00010_010_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Sltu()
        {
            var c = Decode(0b0000000_00100_00010_011_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void And()
        {
            var c = Decode(0b0000000_00100_00010_111_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Or()
        {
            var c = Decode(0b0000000_00100_00010_110_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Xor()
        {
            var c = Decode(0b0000000_00100_00010_100_10001_0110011u);
            //               funct7  rs2   rs1   f3  dest  opcode
            Assert.Equal(RegisterAddressRV32I.R2, c.SourceRegister1);
            Assert.Equal(RegisterAddressRV32I.R4, c.SourceRegister2);
            Assert.Equal(RegisterAddressRV32I.R17, c.DestinationRegister);
        }

        [Fact]
        public void Invalid()
        {
            Assert.Throws<NotSupportedException>(() =>
            {
                var c = Decode(0b1111111_00000_00000_111_00000_0110011u);
            });
        }
    }
}

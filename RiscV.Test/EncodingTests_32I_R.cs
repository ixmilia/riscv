﻿using Xunit;

namespace RiscV.Test
{
    public class EncodingTests_32I_R : TestBase
    {
        [Fact]
        public void Add()
        {
            var i = InstructionRV32I_R.Add(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0000000_00100_00010_000_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }

        [Fact]
        public void Sub()
        {
            var i = InstructionRV32I_R.Sub(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0100000_00100_00010_000_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }

        [Fact]
        public void Sll()
        {
            var i = InstructionRV32I_R.Sll(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0000000_00100_00010_001_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }

        [Fact]
        public void Srl()
        {
            var i = InstructionRV32I_R.Srl(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0000000_00100_00010_101_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }

        [Fact]
        public void Sra()
        {
            var i = InstructionRV32I_R.Sra(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0100000_00100_00010_101_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }

        [Fact]
        public void Slt()
        {
            var i = InstructionRV32I_R.Slt(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, RegisterAddressRV32I.R4);
            AssertEqualBinary(0b0000000_00100_00010_010_10001_0110011u, i.Code);
            //                  funct7  rs2   rs1   f3  dest  opcode
        }
    }
}

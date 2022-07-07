using Xunit;

namespace IxMilia.RiscV.Test
{
    public class EncodingTests_32I_I : TestBase
    {
        protected static void AssertEqualBinary(uint expected, uint actual)
        {
            var indices = new[] { 12, 17, 20, 25 };
            var expectedS = AsBinary(expected, indices);
            var actualS = AsBinary(actual, indices);
            Assert.Equal(expectedS, actualS);
        }

        [Fact]
        public void I_rd()
        {
            var i = InstructionRV32I_I.LW(RegisterAddressRV32I.R31, RegisterAddressRV32I.R0, 0);
            AssertEqualBinary(0b000000000000_00000_010_11111_0000011u, i.Code);
            //                  immediate    rs1   f3  rd    opcode
        }

        [Fact]
        public void I_rs1()
        {
            var i = InstructionRV32I_I.LW(RegisterAddressRV32I.R0, RegisterAddressRV32I.R31, 0);
            AssertEqualBinary(0b000000000000_11111_010_00000_0000011u, i.Code);
            //                  immediate    rs1   f3  rd    opcode
        }

        [Fact]
        public void I_Immediate_11_0()
        {
            var i = InstructionRV32I_I.LW(RegisterAddressRV32I.R0, RegisterAddressRV32I.R0, 0b111111111111);
            AssertEqualBinary(0b111111111111_00000_010_00000_0000011u, i.Code);
            //                  immediate    rs1   f3  rd    opcode
        }

        [Fact]
        public void LW()
        {
            var i = InstructionRV32I_I.LW(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_010_10001_0000011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void LH()
        {
            var i = InstructionRV32I_I.LH(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_001_10001_0000011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void LHU()
        {
            var i = InstructionRV32I_I.LHU(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_101_10001_0000011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void LB()
        {
            var i = InstructionRV32I_I.LB(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_000_10001_0000011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void LBU()
        {
            var i = InstructionRV32I_I.LBU(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_100_10001_0000011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void AddI()
        {
            var i = InstructionRV32I_I.AddI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_000_10001_0010011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void SltI()
        {
            var i = InstructionRV32I_I.SltI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_010_10001_0010011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void SltIU()
        {
            var i = InstructionRV32I_I.SltIU(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 4);
            AssertEqualBinary(0b000000000100_00010_011_10001_0010011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void AndI()
        {
            var i = InstructionRV32I_I.AndI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_111_10001_0010011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void OrI()
        {
            var i = InstructionRV32I_I.OrI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_110_10001_0010011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void XorI()
        {
            var i = InstructionRV32I_I.XorI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, -4);
            AssertEqualBinary(0b111111111100_00010_100_10001_0010011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void SllI()
        {
            var i = InstructionRV32I_I.SllI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 2);
            AssertEqualBinary(0b0000000_00010_00010_001_10001_0010011u, i.Code);
            //                  empty   shamt rs1   f3  dest  opcode
        }

        [Fact]
        public void SrlI()
        {
            var i = InstructionRV32I_I.SrlI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 2);
            AssertEqualBinary(0b0000000_00010_00010_101_10001_0010011u, i.Code);
            //                  empty   shamt rs1   f3  dest  opcode
        }

        [Fact]
        public void SraI()
        {
            var i = InstructionRV32I_I.SraI(RegisterAddressRV32I.R17, RegisterAddressRV32I.R2, 2);
            AssertEqualBinary(0b0100000_00010_00010_101_10001_0010011u, i.Code);
            //                   flag   shamt rs1   f3  dest  opcode
        }

        [Fact]
        public void Nop()
        {
            var i = InstructionRV32I_I.Nop();
            AssertEqualBinary(0b000000000000_00000_000_00000_0010011u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }

        [Fact]
        public void Jalr()
        {
            var i = InstructionRV32I_I.Jalr(RegisterAddressRV32I.R2, RegisterAddressRV32I.R17, -4);
            AssertEqualBinary(0b111111111100_10001_000_00010_1100111u, i.Code);
            //                  immediate    rs1   f3  dest  opcode
        }
    }
}

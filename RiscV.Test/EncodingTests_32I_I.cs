using Xunit;

namespace RiscV.Test
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
    }
}

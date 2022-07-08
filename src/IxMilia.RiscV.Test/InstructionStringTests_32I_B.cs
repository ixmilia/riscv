using Xunit;

namespace IxMilia.RiscV.Test
{
    public class InstructionStringTests_32I_B : TestBase
    {
        [Fact]
        public void Beq()
        {
            AssertInstruction(IInstructionRV32I.Beq(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "beq x2, x3, 0x1234");
        }

        [Fact]
        public void Bne()
        {
            AssertInstruction(IInstructionRV32I.Bne(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bne x2, x3, 0x1234");
        }

        [Fact]
        public void Blt()
        {
            AssertInstruction(IInstructionRV32I.Blt(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "blt x2, x3, 0x1234");
        }

        [Fact]
        public void BltU()
        {
            AssertInstruction(IInstructionRV32I.BltU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bltu x2, x3, 0x1234");
        }

        [Fact]
        public void Bge()
        {
            AssertInstruction(IInstructionRV32I.Bge(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bge x2, x3, 0x1234");
        }

        [Fact]
        public void BgeU()
        {
            AssertInstruction(IInstructionRV32I.BgeU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bgeu x2, x3, 0x1234");
        }

        [Fact]
        public void Bgt()
        {
            AssertInstruction(IInstructionRV32I.Bgt(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "blt x3, x2, 0x1234");
        }

        [Fact]
        public void BgtU()
        {
            AssertInstruction(IInstructionRV32I.BgtU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bltu x3, x2, 0x1234");
        }

        [Fact]
        public void Ble()
        {
            AssertInstruction(IInstructionRV32I.Ble(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bge x3, x2, 0x1234");
        }

        [Fact]
        public void BleU()
        {
            AssertInstruction(IInstructionRV32I.BleU(RegisterAddressRV32I.R2, RegisterAddressRV32I.R3, 0x1234), "bgeu x3, x2, 0x1234");
        }

        [Theory]
        [InlineData("blt x2, x3, 0x1234", "bgt x3, x2, 0x1234")]
        [InlineData("bltu x2, x3, 0x1234", "bgtu x3, x2, 0x1234")]
        [InlineData("bge x2, x3, 0x1234", "ble x3, x2, 0x1234")]
        [InlineData("bgeu x2, x3, 0x1234", "bleu x3, x2, 0x1234")]
        public void ParseAlternates(string canonical, string alternate)
        {
            var canonicalParsed = IInstructionRV32I.Parse(canonical);
            var alternateParsed = IInstructionRV32I.Parse(alternate);
            Assert.Equal(canonicalParsed.ToString(), alternateParsed.ToString());
        }
    }
}

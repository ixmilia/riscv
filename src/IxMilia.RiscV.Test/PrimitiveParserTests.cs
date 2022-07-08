using Xunit;

namespace IxMilia.RiscV.Test
{
    public class PrimitiveParserTests
    {
        [Theory]
        [InlineData("0", 0u)]
        [InlineData("0x1234", 0x1234u)]
        [InlineData("20", 20u)]
        [InlineData("-500", 0xFFFFFE0Cu)]
        public void Numbers(string s, uint expected)
        {
            var actual = s.ParseNumber();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("x0", RegisterAddressRV32I.R0)]
        [InlineData("x1", RegisterAddressRV32I.R1)]
        [InlineData("x2", RegisterAddressRV32I.R2)]
        [InlineData("x3", RegisterAddressRV32I.R3)]
        [InlineData("x4", RegisterAddressRV32I.R4)]
        [InlineData("x5", RegisterAddressRV32I.R5)]
        [InlineData("x6", RegisterAddressRV32I.R6)]
        [InlineData("x7", RegisterAddressRV32I.R7)]
        [InlineData("x8", RegisterAddressRV32I.R8)]
        [InlineData("x9", RegisterAddressRV32I.R9)]
        [InlineData("x10", RegisterAddressRV32I.R10)]
        [InlineData("x11", RegisterAddressRV32I.R11)]
        [InlineData("x12", RegisterAddressRV32I.R12)]
        [InlineData("x13", RegisterAddressRV32I.R13)]
        [InlineData("x14", RegisterAddressRV32I.R14)]
        [InlineData("x15", RegisterAddressRV32I.R15)]
        [InlineData("x16", RegisterAddressRV32I.R16)]
        [InlineData("x17", RegisterAddressRV32I.R17)]
        [InlineData("x18", RegisterAddressRV32I.R18)]
        [InlineData("x19", RegisterAddressRV32I.R19)]
        [InlineData("x20", RegisterAddressRV32I.R20)]
        [InlineData("x21", RegisterAddressRV32I.R21)]
        [InlineData("x22", RegisterAddressRV32I.R22)]
        [InlineData("x23", RegisterAddressRV32I.R23)]
        [InlineData("x24", RegisterAddressRV32I.R24)]
        [InlineData("x25", RegisterAddressRV32I.R25)]
        [InlineData("x26", RegisterAddressRV32I.R26)]
        [InlineData("x27", RegisterAddressRV32I.R27)]
        [InlineData("x28", RegisterAddressRV32I.R28)]
        [InlineData("x29", RegisterAddressRV32I.R29)]
        [InlineData("x30", RegisterAddressRV32I.R30)]
        [InlineData("x31", RegisterAddressRV32I.R31)]
        public void Registers(string s, RegisterAddressRV32I expected)
        {
            var actual = s.ParseRegister();
            Assert.Equal(expected, actual);
        }
    }
}

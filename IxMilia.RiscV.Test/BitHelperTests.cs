using Xunit;

namespace IxMilia.RiscV.Test
{
    public class BitHelperTests
    {
        [Fact]
        public void GetMask()
        {
            Assert.Equal(0b00000001u, BitMaskHelpers.GetMask(1));
            Assert.Equal(0b11111111u, BitMaskHelpers.GetMask(8));
            Assert.Equal(0b11111111111u, BitMaskHelpers.GetMask(11));
        }

        [Fact]
        public void GetBitsUint()
        {
            Assert.Equal(0b00011111u, BitMaskHelpers.GetBitsUint(0b00111110, 1, 5));
        }

        [Fact]
        public void SetBitsUint()
        {
            Assert.Equal(0b10111110u, BitMaskHelpers.SetBitsUint(0b10000000u, 1, 5, 0b11111));
        }
    }
}